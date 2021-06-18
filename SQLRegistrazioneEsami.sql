--Lo studente è definito con:
--•	Nome
--•	Cognome
--•	AnnoNascita
--L’esame è definito da:
--•	Nome
--•	CFU
--•	Data
--•	Votazione
--•	Passato

create database RegistrazioneEsami

create table studente(
       id int identity(1,1)not null,
	   nome varchar(20) not null,
	   cognome varchar(20) not null,
	   annoNascita int not null,
	   primary key(id),
	   check(annoNascita > 0)
	   
	   )

	   create table Esame(
	   id int identity(1,1) not null,
	   nome varchar(50)not null,
	   cfu int not null,
	   dataEsame date not null,
	   votazione float not null,
	   passato bit, --1 per true e 0 per false
	   idStudente int,
	   primary key(id),
	   foreign key(idStudente) references studente(id),
	   check(cfu >0),
	   check(votazione > 18 or votazione <= 30 or votazione =0),
	   check(passato in('1','0'))    --CHECK (Ruolo IN ('Protagonista', 'Secondario', 'Comparsa')),
	   
	   )
	   

	   insert into Studente values('Orlando','Bloom', 1994),('Katy','Perry',2001),
	   ('Jhon','Travolta',1993),('Jhonny','Deep',1999),('Hugh','Grant',1997)
	   select * from studente
	   insert into Esame values('Storia della filosofia',6,'2021-06-12',23,1,2),
	   ('Storia della filosofia',6,'2021-06-12',29,1,6),('Glottologia',10,'2021-06-11',0,0,6),
	   ('Storia della filosofia',6,'2021-05-11',21,1,5),('Glottologia',10,'2021-06-11',18,1,3),
	   ('Fonetica',8,'2021-04-29',0,0,2),('fonetica',8,'2021-04-29',30,1,4),
	   ('Tradizioni convenzionali',3,'2021-03-12',26,1,3),('Tradizioni convenzionali',3,'2021-05-12',29,1,2),
	   ('Tradizioni convenzionali',3,'2021-03-12',19,1,4)