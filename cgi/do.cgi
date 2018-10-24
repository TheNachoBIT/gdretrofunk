#!/usr/bin/perl
use strict;
use warnings;
use DBI;
use CGI;
my $CGI = new CGI;
use Digest::SHA qw(sha256_hex);
=comment
Conectar a la base de datos
Huelgo de contar a vuestra mercerd que Perl no es un lenguaje de programación hecho para
crear cosas en web, pero se entiende no?
de todas formas es por el modulo
=cut
print $CGI->header;
my $rank = 0;
my $dbh = DBI->connect("DBI:mysql:database=registros;host=localhost",
                       "user", "pass",
                       {'RaiseError' => 1});
#Vuestra Merced sabrá los formularios POST
my $user = $CGI->param("user");
my $pass = $CGI->param("pass"); 
my $password = sha256_hex($pass);
# Contar letras en string
my $len = map $_, $user =~ /(.)/gs;
if ($len>12) {
print("Menos de 12 caracteres");
die;
}
# Ver si ya existe un usuario con ese nombre
my $resultado = $dbh->do("SELECT * FROM users WHERE users= ". $dbh->quote($user));
if ($resultado > 0) {
#print $resultado;
print "1";
	exit;
}
# No preguntes
$dbh->do("INSERT INTO users (users, passwd, rank) VALUES (" . $dbh->quote($user) . "," . $dbh->quote($password) . "," . $dbh->quote($rank) . ")");
print "0";
$dbh->disconnect();
