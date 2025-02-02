-- DROP SCHEMA public;

CREATE SCHEMA public AUTHORIZATION pg_database_owner;

-- DROP SEQUENCE public.campaign_id_seq;

CREATE SEQUENCE public.campaign_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.campaignusers_id_seq;

CREATE SEQUENCE public.campaignusers_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.character_id_seq;

CREATE SEQUENCE public.character_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.character_relations_id_seq;

CREATE SEQUENCE public.character_relations_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.map_id_seq;

CREATE SEQUENCE public.map_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.pin_id_seq;

CREATE SEQUENCE public.pin_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;
-- DROP SEQUENCE public.user_id_seq;

CREATE SEQUENCE public.user_id_seq
	INCREMENT BY 1
	MINVALUE 1
	MAXVALUE 9223372036854775807
	START 1
	CACHE 1
	NO CYCLE;-- public.campaign definition

-- Drop table

-- DROP TABLE public.campaign;

CREATE TABLE public.campaign (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT campaign_pk PRIMARY KEY (id)
);


-- public."user" definition

-- Drop table

-- DROP TABLE public."user";

CREATE TABLE public."user" (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	username varchar NOT NULL,
	"password" varchar NOT NULL,
	CONSTRAINT user_pk PRIMARY KEY (id),
	CONSTRAINT user_unique UNIQUE (username)
);


-- public.campaign_user definition

-- Drop table

-- DROP TABLE public.campaign_user;

CREATE TABLE public.campaign_user (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	userid varchar NOT NULL,
	isowner bool NOT NULL,
	campaignid int8 NOT NULL,
	CONSTRAINT campaignuser_unique UNIQUE (userid, campaignid),
	CONSTRAINT campaignusers_pk PRIMARY KEY (id),
	CONSTRAINT campaignusers_campaign_fk FOREIGN KEY (campaignid) REFERENCES public.campaign(id),
	CONSTRAINT campaignusers_user_fk FOREIGN KEY (userid) REFERENCES public."user"(username)
);


-- public."character" definition

-- Drop table

-- DROP TABLE public."character";

CREATE TABLE public."character" (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	"name" varchar NOT NULL,
	userid varchar NOT NULL,
	campaignid int8 NULL,
	race varchar NOT NULL,
	CONSTRAINT character_pk PRIMARY KEY (id),
	CONSTRAINT character_campaign_fk FOREIGN KEY (campaignid) REFERENCES public.campaign(id),
	CONSTRAINT character_user_fk FOREIGN KEY (userid) REFERENCES public."user"(username)
);


-- public.character_relation definition

-- Drop table

-- DROP TABLE public.character_relation;

CREATE TABLE public.character_relation (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	from_character int8 NOT NULL,
	to_character int8 NOT NULL,
	relation varchar NULL,
	campaignid int8 NOT NULL,
	CONSTRAINT character_relations_pk PRIMARY KEY (id),
	CONSTRAINT character_relation_campaign_fk FOREIGN KEY (campaignid) REFERENCES public.campaign(id),
	CONSTRAINT character_relation_character_fk FOREIGN KEY (from_character) REFERENCES public."character"(id),
	CONSTRAINT character_relation_character_fk_1 FOREIGN KEY (to_character) REFERENCES public."character"(id)
);


-- public."map" definition

-- Drop table

-- DROP TABLE public."map";

CREATE TABLE public."map" (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	image_location varchar NOT NULL,
	campaignid int8 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT map_pk PRIMARY KEY (id),
	CONSTRAINT map_campaign_fk FOREIGN KEY (campaignid) REFERENCES public.campaign(id)
);


-- public.pin definition

-- Drop table

-- DROP TABLE public.pin;

CREATE TABLE public.pin (
	id int8 GENERATED ALWAYS AS IDENTITY( INCREMENT BY 1 MINVALUE 1 MAXVALUE 9223372036854775807 START 1 CACHE 1 NO CYCLE) NOT NULL,
	mapid int8 NOT NULL,
	xpos int8 NOT NULL,
	ypos int8 NOT NULL,
	"name" varchar NOT NULL,
	description varchar NULL,
	CONSTRAINT pin_pk PRIMARY KEY (id),
	CONSTRAINT pin_map_fk FOREIGN KEY (mapid) REFERENCES public."map"(id)
);