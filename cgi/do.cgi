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

my $dbh = DBI->connect("DBI:mysql:database=registros;host=localhost",
                       "user", "pass",
                       {'RaiseError' => 1});
#Vuestra Merced sabrá los formularios POST
my $user = $CGI->param("user");
my $pass = $CGI->param("pass");
my $password = sha256_hex($pass);
# Como Vuestra Merced habrá supuesto, al ser un Query SQL, es igual.

#Huelgo de contar a Vuestra Merced que es menester ver si hay un usuario con el mismo nombre
my $len = map $_, $user =~ /(.)/gs;
if ($len>12) {
print("Menos de 12 caracteres");
die;
}
my $resultado = $dbh->do("SELECT * FROM users WHERE users= ". $dbh->quote($user));
if ($resultado > 0) {
#print $resultado;
print "1";
	exit;
}
$dbh->do("INSERT INTO users (users, passwd) VALUES " . $dbh->quote($user) . "," . $dbh->quote($password));
print "0";
# Desconectole a la base de datos
$dbh->disconnect();
# De lo que de aquí adelante me sucediere avisare a vuestra merced.
