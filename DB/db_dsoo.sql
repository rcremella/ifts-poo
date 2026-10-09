drop database if exists dsoo;

CREATE DATABASE dsoo;
USE dsoo;
CREATE TABLE persona (id int primary key auto_increment,
                    nombre varchar(255),
                    apellido varchar(255),
                    documento int UNIQUE ,
                    telefono varchar(12));
CREATE TABLE cliente (id int primary key auto_increment,
                    id_persona int,
                    tipo enum("socio", "noSocio"),
                    apto_fisico bool,
                    fechaVto date);      
CREATE TABLE pago (id int primary key auto_increment, 
                        id_cliente int, 
                        importe decimal (10,2),
                        fecha_pago date,
                        tipo_pago varchar(50));
CREATE TABLE carnet (id int primary key auto_increment, 
                        id_cliente int,
                        fecha_entrega date,
                        emitido bool);
CREATE TABLE usuario ( id int primary key auto_increment,
						nombreUsuario varchar(20),
						nombre varchar(50),
						apellido varchar(50),
						funcion varchar(50),
						clave varchar(255)
						);
INSERT INTO usuario(nombreUsuario, nombre, apellido, funcion, clave) 
VALUES("empleado1", "Esteban", "Quito", "Administracion", "123456");


						
