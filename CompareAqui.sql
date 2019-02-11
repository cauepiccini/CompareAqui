CREATE DATABASE CompareAqui;

USE CompareAqui;


CREATE TABLE `tb_lista` (
  `list_id` int(11) NOT NULL PRIMARY KEY,
  `list_nome` varchar(45) NOT NULL,
  `list_categoria` varchar(45) NOT NULL,
  `list_mercado` varchar(45) NOT NULL,
  `list_preco` varchar(45) NOT NULL
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;



CREATE TABLE `tb_usuario` (
  `usu_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `usu_nome` varchar(90) NOT NULL,
  `usu_sexo` varchar(20) NOT NULL,
  `usu_nascimento` varchar(10) NOT NULL,
  `usu_email` varchar(45) NOT NULL,
  `usu_senha` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;



CREATE TABLE `tb_produto` (
  `prod_cod` int(30) NOT NULL PRIMARY KEY,
  `prod_nome` varchar(45) NOT NULL,
  `prod_categoria` varchar(45) NOT NULL,
  `prod_mercado` varchar(45) NOT NULL,
  `prod_preco` decimal(8,2) NOT NULL,
  `prod_peso` decimal(8,2) NOT NULL,
  `prod_marca` varchar(45) NOT NULL,
  `prod_quantidade` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;



CREATE TABLE `tb_usuarioempresa` (
  `usu_id` int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  `usu_RazaoSocial` varchar(45) NOT NULL,
  `usu_CNPJ` varchar(20) NOT NULL,
  `usu_Endereco` varchar(45) NOT NULL,
  `usu_Numero` int(5) NOT NULL,
  `usu_Bairro` varchar(45) NOT NULL,
  `usu_Municipio` varchar(45) NOT NULL,
  `usu_Estado` varchar(2) NOT NULL,
  `usu_CEP` int(10) NOT NULL,
  `usu_Telefone1` varchar(20) NOT NULL,
  `usu_Telefone2` varchar(20) NOT NULL,
  `usu_Usuario` varchar(45) NOT NULL,
  `usu_Senha` varchar(20) NOT NULL,
  `usu_Responsavel` varchar(45) NOT NULL,
  `usu_Email` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;