#!/usr/bin/perl
use Digest::SHA qw(sha256_hex);
use DBI;
use CGI;
my $cgi = new CGI;
my $db = DBI->connect("DBI:mysql:database=registros:host=localhost",
		      "user","password",{'RaiseError'=> 1});
print $cgi->header;
my $user = $cgi->param("user");
my $pass = $cgi->param("pass");
my $password = sha256_hex($pass);
my $XD = $db->do("SELECT * FROM users WHERE users= " . $db->quote($user) . "AND passwd=" . $db->quote($password));
if ($XD == 1) {
    printf("1");
}
else {
    print("0");
    die;
}
