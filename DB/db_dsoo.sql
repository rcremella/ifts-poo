drop database if exists dsoo;

CREATE DATABASE dsoo;
USE dsoo;

CREATE TABLE persona (id int primary key auto_increment,
                    nombre varchar(255),
                    apellido varchar(255),
                    documento int UNIQUE,
                    telefono varchar(12),
                    apto_fisico int);

CREATE TABLE cliente (id int primary key auto_increment,
                    id_persona int,
                    tipo enum("socio", "noSocio"),
                    fechaVto date,
                    apto_fisico tinyint(1),
                    importe decimal(10,0));

CREATE TABLE no_cliente (id int primary key auto_increment,
                    id_persona int,
                    importe decimal(6,2),
                    KEY id_persona (id_persona));

CREATE TABLE precio (id int primary key auto_increment,
                    detalle enum("socio", "no_socio"),
                    importe decimal(10,0));

CREATE TABLE pago (id int primary key auto_increment,
                    id_persona int,
                    importe decimal(10,2),
                    fecha_pago date,
                    tipo_pago varchar(50),
                    KEY fk_pago_id_persona (id_persona));

CREATE TABLE carnet (id int primary key auto_increment,
                    id_cliente int,
                    fecha_entrega date,
                    emitido tinyint(1));

CREATE TABLE usuario (id int primary key auto_increment,
                    nombreUsuario varchar(20),
                    nombre varchar(50),
                    apellido varchar(50),
                    funcion varchar(50),
                    clave varchar(255));

INSERT INTO precio(detalle, importe)
VALUES("socio", 50000), ("no_socio", 4000);

INSERT INTO usuario(nombreUsuario, nombre, apellido, funcion, clave)
VALUES("empleado1", "Esteban", "Quito", "Administracion", "123456");
