CREATE TABLE "Roles" (
	"id" serial NOT NULL,
	"role_name" character varying NOT NULL,
	CONSTRAINT "Roles_pk" PRIMARY KEY ("id")
) WITH (
  OIDS=FALSE
);

CREATE TABLE "Users" (
	"id" serial NOT NULL PRIMARY KEY,
	"first_name" character varying NOT NULL,
	"email" character varying NOT NULL,
	"role" serial NOT NULL,
	"password" character varying NOT NULL
) WITH (
  OIDS=FALSE
);
ALTER TABLE "Users" ADD CONSTRAINT "RolesOfUsers_fk0"
FOREIGN KEY ("role") REFERENCES "Roles"("id");

insert into "Roles"("id", "role_name") values (1, 'Admin'),(2, 'User'),(3, 'Guest');


