CREATE DATABASE IF NOT EXISTS usuarios_bbdd;

USE usuarios_bbdd;


CREATE TABLE IF NOT EXISTS Usuarios (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50),
    apellido VARCHAR(50),
    email VARCHAR(100),
    direccion VARCHAR(100),
    pais VARCHAR(50)
);

INSERT INTO Usuarios (nombre, apellido, email, direccion, pais) VALUES 
    ('Juan', 'Perez', 'juan@mail.com', 'Calle Principal', 'España'),
    ('Maria', 'Garcia', 'maria@mail.com', 'Avenida Libertad', 'México'),
    ('Pedro', 'Rodriguez', 'pedro@mail.com', 'Rua das Flores', 'Brasil'),
    ('Ana', 'Lopez', 'ana@mail.com', 'Elm Street', 'Estados Unidos'),
    ('Luis', 'Martinez', 'luis@mail.com', 'Boulevard des Fleurs', 'Francia'),
	('Laura', 'Gomez', 'laura@mail.com', 'Via Roma', 'Italia'),
    ('Carlos', 'Sanchez', 'carlos@mail.com', 'Munich', 'Alemania'),
    ('Sofia', 'Hernandez', 'sofia@mail.com', 'Rua Direita', 'Portugal'),
    ('Daniel', 'Diaz', 'daniel@mail.com', 'High Street', 'Reino Unido'),
    ('Elena', 'Alvarez', 'elena@mail.com', 'Rue Principale', 'Canadá');