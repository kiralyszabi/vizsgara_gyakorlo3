-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Már 26. 20:01
-- Kiszolgáló verziója: 10.4.28-MariaDB
-- PHP verzió: 8.2.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `euroskills`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `dijazas`
--

CREATE TABLE `dijazas` (
  `dijazas_id` int(11) NOT NULL,
  `dijazas_versenyzo` int(11) NOT NULL,
  `dijazas_osszeg` int(11) NOT NULL,
  `dijazas_megjegyzes` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

--
-- A tábla adatainak kiíratása `dijazas`
--

INSERT INTO `dijazas` (`dijazas_id`, `dijazas_versenyzo`, `dijazas_osszeg`, `dijazas_megjegyzes`) VALUES
(1, 122, 300, 'különdíj');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `dijazas`
--
ALTER TABLE `dijazas`
  ADD PRIMARY KEY (`dijazas_id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `dijazas`
--
ALTER TABLE `dijazas`
  MODIFY `dijazas_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
