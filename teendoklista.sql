-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2020. Ápr 20. 14:31
-- Kiszolgáló verziója: 10.4.8-MariaDB
-- PHP verzió: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `teendoklista`
--
CREATE DATABASE IF NOT EXISTS `teendoklista` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `teendoklista`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ertekezlet`
--

CREATE TABLE `ertekezlet` (
  `id` int(11) NOT NULL,
  `nev` varchar(255) NOT NULL,
  `kezdet_datum` datetime NOT NULL,
  `veg_datum` datetime DEFAULT NULL,
  `leiras` text DEFAULT NULL,
  `letszam` int(3) DEFAULT NULL,
  `online` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `ertekezlet`
--

INSERT INTO `ertekezlet` (`id`, `nev`, `kezdet_datum`, `veg_datum`, `leiras`, `letszam`, `online`) VALUES
(1, 'MVC előadás', '2020-04-20 17:30:00', '2020-04-20 20:00:00', 'Előadás az ASP.NET MVC-ről', 20, 1),
(2, 'Honlap tervezés ügyféllel', '2020-04-21 00:00:00', NULL, NULL, NULL, 0),
(4, 'Tanári értekezlet', '2020-04-23 08:00:00', NULL, 'Év vizsgák átbeszélése', 20, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `feladat`
--

CREATE TABLE `feladat` (
  `Id` int(11) NOT NULL,
  `Cim` varchar(50) NOT NULL,
  `Szoveg` varchar(255) DEFAULT NULL,
  `LetrehozasDatum` datetime NOT NULL,
  `Teljesitve` tinyint(1) NOT NULL,
  `felhasznaloId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `feladat`
--

INSERT INTO `feladat` (`Id`, `Cim`, `Szoveg`, `LetrehozasDatum`, `Teljesitve`, `felhasznaloId`) VALUES
(1, 'Első feladat', 'Teszt szöveg', '2019-11-19 00:00:00', 1, 1),
(2, 'Második feladat', 'Teszt szöveg', '2019-11-20 00:00:00', 0, 1),
(3, 'Harmadik feladat', 'Ez a felhasználó hozta létre', '2020-04-13 00:00:00', 0, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `Id` int(11) NOT NULL,
  `FelhasznaloNev` varchar(255) NOT NULL,
  `Jelszo` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`Id`, `FelhasznaloNev`, `Jelszo`) VALUES
(1, 'admin', '25F43B1486AD95A1398E3EEB3D83BC4010015FCC9BEDB35B432E00298D5021F7'),
(2, 'user', '5FECEB66FFC86F38D952786C6D696C79C2DBC239DD4E91B46729D73A27FB57E9');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `ertekezlet`
--
ALTER TABLE `ertekezlet`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `feladat`
--
ALTER TABLE `feladat`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`),
  ADD KEY `IX_FK_felhasznalofeladat` (`felhasznaloId`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `Id` (`Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ertekezlet`
--
ALTER TABLE `ertekezlet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT a táblához `feladat`
--
ALTER TABLE `feladat`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `feladat`
--
ALTER TABLE `feladat`
  ADD CONSTRAINT `FK_felhasznalofeladat` FOREIGN KEY (`felhasznaloId`) REFERENCES `felhasznalo` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
