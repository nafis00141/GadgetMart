-- phpMyAdmin SQL Dump
-- version 3.4.5
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Aug 02, 2017 at 11:23 PM
-- Server version: 5.5.16
-- PHP Version: 5.3.8

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `gmart`
--

-- --------------------------------------------------------

--
-- Table structure for table `tblbrands`
--

CREATE TABLE IF NOT EXISTS `tblbrands` (
  `BrandID` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`BrandID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `tblbrands`
--

INSERT INTO `tblbrands` (`BrandID`, `Name`) VALUES
(2, 'Samsung'),
(5, 'AMD'),
(6, 'Oculus'),
(7, 'Nvidia');

-- --------------------------------------------------------

--
-- Table structure for table `tblcategories`
--

CREATE TABLE IF NOT EXISTS `tblcategories` (
  `CatID` int(11) NOT NULL AUTO_INCREMENT,
  `CatName` varchar(255) NOT NULL,
  PRIMARY KEY (`CatID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=7 ;

--
-- Dumping data for table `tblcategories`
--

INSERT INTO `tblcategories` (`CatID`, `CatName`) VALUES
(1, 'Mobile'),
(4, 'GPU'),
(5, 'Laptop'),
(6, 'VR');

-- --------------------------------------------------------

--
-- Table structure for table `tblproductimages`
--

CREATE TABLE IF NOT EXISTS `tblproductimages` (
  `PIMGID` int(11) NOT NULL AUTO_INCREMENT,
  `PID` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Extention` varchar(255) NOT NULL,
  PRIMARY KEY (`PIMGID`),
  KEY `PID` (`PID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `tblproductimages`
--

INSERT INTO `tblproductimages` (`PIMGID`, `PID`, `Name`, `Extention`) VALUES
(1, 1, 'Samsung Galaxy S801', '.jpg'),
(2, 1, 'Samsung Galaxy S802', '.jpg'),
(3, 1, 'Samsung Galaxy S803', '.jpg'),
(7, 3, 'Oculus Rift01', '.jpg'),
(8, 3, 'Oculus Rift02', '.jpg'),
(9, 3, 'Oculus Rift03', '.jpg'),
(10, 4, 'Nvidia 1080ti01', '.jpg'),
(11, 4, 'Nvidia 1080ti02', '.jpg'),
(12, 4, 'Nvidia 1080ti03', '.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `tblproducts`
--

CREATE TABLE IF NOT EXISTS `tblproducts` (
  `PID` int(11) NOT NULL AUTO_INCREMENT,
  `PName` varchar(255) NOT NULL,
  `PPrice` int(11) NOT NULL,
  `PSellPrice` int(11) NOT NULL,
  `PBrandID` int(11) NOT NULL,
  `PCategoryID` int(11) NOT NULL,
  `PQuantity` int(11) NOT NULL,
  `PProductDetails` varchar(255) NOT NULL,
  `FreeDelivery` int(11) NOT NULL,
  `3DayReturn` int(11) NOT NULL,
  `COD` int(11) NOT NULL,
  PRIMARY KEY (`PID`),
  KEY `PBrandID` (`PBrandID`),
  KEY `PCategoryID` (`PCategoryID`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Dumping data for table `tblproducts`
--

INSERT INTO `tblproducts` (`PID`, `PName`, `PPrice`, `PSellPrice`, `PBrandID`, `PCategoryID`, `PQuantity`, `PProductDetails`, `FreeDelivery`, `3DayReturn`, `COD`) VALUES
(1, 'Samsung Galaxy S8', 77000, 78000, 2, 1, 483, '6.0" Super AMOLED Display\r\nOcta-Core, Clock Speed Quad 2.35GHz + Quad 1.7GHz\r\n4GB RAM and 64GB ROM \r\nMicroSD Support up to 256GB\r\n12MP Rear and 8MP Front Camera\r\nDual SIM\r\nAndroid 7.0 (Nougat)\r\n3000mAh Battery', 1, 1, 1),
(3, 'Oculus Rift', 50000, 52000, 6, 6, 8, 'Oculus Rift VR', 0, 0, 1),
(4, 'Nvidia 1080ti', 68000, 70000, 7, 4, 9, 'Geforce GTX 1080ti VR Ready ', 0, 0, 1);

-- --------------------------------------------------------

--
-- Table structure for table `tblsold`
--

CREATE TABLE IF NOT EXISTS `tblsold` (
  `sid` int(11) NOT NULL AUTO_INCREMENT,
  `uid` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `num` varchar(255) NOT NULL,
  `add` varchar(255) NOT NULL,
  `done` bit(1) NOT NULL,
  PRIMARY KEY (`sid`),
  KEY `uid` (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Dumping data for table `tblsold`
--

INSERT INTO `tblsold` (`sid`, `uid`, `date`, `num`, `add`, `done`) VALUES
(1, 1002, '2017-08-02 18:35:51', '+8801534518285', 'kjfdlnfv', '1'),
(2, 1003, '2017-08-02 22:40:31', '01673581259', 'Mirpur', '1'),
(3, 1003, '2017-08-03 00:27:12', 'dfsdv', 'sdgsdg', '1'),
(4, 1002, '2017-08-03 01:37:44', '01819428599', '141 kalabagan dhaka', '1'),
(5, 1002, '2017-08-03 02:00:03', '01458643543', 'dfgdfg', '0'),
(6, 1002, '2017-08-03 02:03:00', 'asd', 'asdas', '0'),
(7, 1002, '2017-08-03 03:13:05', '01819428599', '141 kalabagan dhaka', '1'),
(8, 1002, '2017-08-03 03:18:54', '01819428599', '141 kalabagan dhaka', '0');

-- --------------------------------------------------------

--
-- Table structure for table `tblsolditem`
--

CREATE TABLE IF NOT EXISTS `tblsolditem` (
  `sid` int(11) NOT NULL,
  `pid` int(11) NOT NULL,
  KEY `pid` (`pid`),
  KEY `sid` (`sid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tblsolditem`
--

INSERT INTO `tblsolditem` (`sid`, `pid`) VALUES
(1, 1),
(1, 1),
(1, 1),
(2, 1),
(2, 1),
(3, 1),
(4, 1),
(4, 1),
(5, 1),
(5, 1),
(5, 1),
(6, 1),
(6, 1),
(6, 1),
(7, 4),
(7, 3),
(8, 3);

-- --------------------------------------------------------

--
-- Table structure for table `userinfo`
--

CREATE TABLE IF NOT EXISTS `userinfo` (
  `uid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `name` varchar(255) NOT NULL,
  `usertype` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`uid`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=1012 ;

--
-- Dumping data for table `userinfo`
--

INSERT INTO `userinfo` (`uid`, `username`, `password`, `email`, `name`, `usertype`) VALUES
(1001, 'himel36', '123456', 'hafizul@gmail.com', 'Hafizul Islam Himel', 'U'),
(1002, 'nafis014', '123456', 'nafis0014@gmail.com', 'Shahriar Nafis', 'U'),
(1003, 'swapnil', '1234', 'iamswapnil@gmail.com', 'Swapnil Biswas', 'U'),
(1004, 'Shibli', '123', '', '', 'U'),
(1005, 'Shibli', '123', 'shibli', 'Shibli', 'U'),
(1006, 'a', 'b', 'e', 'd', 'U'),
(1007, 'qdas', 'sadas', 'sad', 'sadas', 'U'),
(1008, 'agb', '12', 'asdasd', '141455', 'U'),
(1009, 'ass', '12', '521313514', '1253', 'U'),
(1010, 'admin', 'admin', 'admin@admin.com', 'Admin', 'A'),
(1011, 'Shibli', '123', 'iamshibli@gmail.com', 'Shibli', 'U');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tblproductimages`
--
ALTER TABLE `tblproductimages`
  ADD CONSTRAINT `tblproductimages_ibfk_1` FOREIGN KEY (`PID`) REFERENCES `tblproducts` (`PID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tblproducts`
--
ALTER TABLE `tblproducts`
  ADD CONSTRAINT `tblproducts_ibfk_2` FOREIGN KEY (`PCategoryID`) REFERENCES `tblcategories` (`CatID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tblproducts_ibfk_1` FOREIGN KEY (`PBrandID`) REFERENCES `tblbrands` (`BrandID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tblsold`
--
ALTER TABLE `tblsold`
  ADD CONSTRAINT `tblsold_ibfk_1` FOREIGN KEY (`uid`) REFERENCES `userinfo` (`uid`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `tblsolditem`
--
ALTER TABLE `tblsolditem`
  ADD CONSTRAINT `tblsolditem_ibfk_2` FOREIGN KEY (`sid`) REFERENCES `tblsold` (`sid`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `tblsolditem_ibfk_1` FOREIGN KEY (`pid`) REFERENCES `tblproducts` (`PID`) ON DELETE CASCADE ON UPDATE CASCADE;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
