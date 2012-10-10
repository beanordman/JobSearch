use job_search;

create table Job
(
	ID integer, ClientID integer,	Specification varchar(128), Link varchar(256), PRIMARY KEY(ID)
);

create table Client
(
	ID integer,
	Name varchar(32),
	Contact varchar(32),
	Phone varchar(16),
	Email varchar(64),
	Details varchar(256),
	Url varchar(128),
	PRIMARY KEY(ID)
);

create table Recruiter
(
	ID integer,
	Name varchar(32),
	Agency varchar(32),
	Phone varchar(16),
	Email varchar(64),
	Url varchar(128),
	PRIMARY KEY(ID)	
);

create table Application
(
	ID integer,
	JobID integer,
	RecruiterID integer,
	ApplicationDate date,
	State varchar(64),
	Notes varchar(128),
	InterviewDate date,
	PRIMARY KEY(ID)
);

create table Client_Recruiter
(
	ClientID integer,
	RecruitedID integer,
	PRIMARY KEY(ClientID, RecruitedID)
);




