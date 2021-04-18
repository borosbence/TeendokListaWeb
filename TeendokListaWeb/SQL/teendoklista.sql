-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Ápr 18. 15:24
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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `ertekezlet`
--

CREATE TABLE `ertekezlet` (
  `id` int(11) NOT NULL,
  `nev` varchar(50) NOT NULL,
  `kezdet_datum` datetime NOT NULL,
  `veg_datum` datetime DEFAULT NULL,
  `leiras` mediumtext DEFAULT NULL,
  `letszam` int(3) DEFAULT NULL,
  `online` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `ertekezlet`
--

INSERT INTO `ertekezlet` (`id`, `nev`, `kezdet_datum`, `veg_datum`, `leiras`, `letszam`, `online`) VALUES
(1, 'Online óra', '2021-04-19 05:10:00', '2021-04-19 06:30:00', 'API készítés', 16, 1);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `feladat`
--

CREATE TABLE `feladat` (
  `id` int(11) NOT NULL,
  `cim` varchar(50) CHARACTER SET utf8 NOT NULL,
  `szoveg` text CHARACTER SET utf8 NOT NULL,
  `letrehozas_datum` datetime NOT NULL,
  `teljesitve` tinyint(1) NOT NULL,
  `felhasznalo_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `feladat`
--

INSERT INTO `feladat` (`id`, `cim`, `szoveg`, `letrehozas_datum`, `teljesitve`, `felhasznalo_id`) VALUES
(1, 'Első feladat000', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\f0\\fs17 Form\\lang1033\\f1\\\'e1\\lang1038\\f0 z\\lang1033\\f1\\\'e1\\lang1038\\f0 s befejez\\lang1033\\f1\\\'e9\\lang1038\\f0 se\\par\r\n\\par\r\n\\b\\fs17 Teszt\\b0\\fs17\\par\r\n}\r\n', '2020-11-16 07:00:00', 1, 1),
(2, 'Formázott rész', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n\\viewkind4\\uc1\\pard\\b\\f0\\fs17 F\\lang1033\\f1\\\'e9\\lang1038\\f0 lk\\lang1033\\f1\\\'f6\\lang1038\\f0 v\\lang1033\\f1\\\'e9\\lang1038\\f0 r\\b0\\par\r\n\\i D\\\'f5lt\\i0\\par\r\n\\ul Al\\lang1033\\f1\\\'e1\\lang1038\\f0 h\\lang1033\\f1\\\'fa\\lang1038\\f0 zott\\ulnone\\par\r\n\\lang1033\\strike\\f1\\\'c1\\lang1038\\f0 th\\lang1033\\f1\\\'fa\\lang1038\\f0 zott\\par\r\n\\par\r\n\\b\\strike0\\fs17 Minden \\b0\\i sz\\\'f3\\b\\i0  \\ul\\b0 m\\\'e1shogy\\ulnone\\b  \\b0\\strike form\\\'e1zott\\strike0\\fs17\\par\r\n}\r\n', '2020-11-17 10:00:00', 0, 1),
(3, 'Harmadik feladat', '{\\rtf1\\ansi\\ansicpg1250\\deff0\\nouicompat\\deflang1038{\\fonttbl{\\f0\\fnil\\fcharset238 Microsoft Sans Serif;}{\\f1\\fnil\\fcharset0 Microsoft Sans Serif;}}\r\n{\\*\\generator Riched20 10.0.19041}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs17 J\\f1\\lang1033\\\'f3 reggelt k\\\'edv\\\'e1nok!\\f0\\lang1038\\par\r\n}\r\n', '2021-04-15 12:41:18', 1, 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `felhasznalo`
--

CREATE TABLE `felhasznalo` (
  `id` int(11) NOT NULL,
  `felhasznalonev` varchar(20) CHARACTER SET utf8 NOT NULL,
  `jelszo` varchar(255) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- A tábla adatainak kiíratása `felhasznalo`
--

INSERT INTO `felhasznalo` (`id`, `felhasznalonev`, `jelszo`) VALUES
(1, 'admin', '58B5444CF1B6253A4317FE12DAFF411A78BDA0A95279B1D5768EBF5CA60829E78DA944E8A9160A0B6D428CB213E813525A72650DAC67B88879394FF624DA482F'),
(2, 'user', '661BB43140229AD4DC3E762E7BDD68CC14BB9093C158C386BD989FEA807ACD9BD7F805CA4736B870B6571594D0D8FCFC57B98431143DFB770E083FA9BE89BC72'),
(3, 'operator', '65FD9484FB368D78C993650DA2392D9258B96777725F441FBCE652182E4D8796DA544B8589B4DA47153AF58C5C8DBE52EBACD8BD616DA200A1F5674F84EDFA5D');

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
  ADD PRIMARY KEY (`id`),
  ADD KEY `felhasznalo_id` (`felhasznalo_id`);

--
-- A tábla indexei `felhasznalo`
--
ALTER TABLE `felhasznalo`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `felhasznalonev` (`felhasznalonev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `ertekezlet`
--
ALTER TABLE `ertekezlet`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `feladat`
--
ALTER TABLE `feladat`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `felhasznalo`
--
ALTER TABLE `felhasznalo`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `feladat`
--
ALTER TABLE `feladat`
  ADD CONSTRAINT `feladat_ibfk_1` FOREIGN KEY (`felhasznalo_id`) REFERENCES `felhasznalo` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
