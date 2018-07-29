-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 10, 2018 at 05:33 AM
-- Server version: 10.1.28-MariaDB
-- PHP Version: 7.1.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `prodb`
--

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `AtID` int(11) NOT NULL,
  `EmpID` int(11) NOT NULL,
  `OTHours` int(2) DEFAULT NULL,
  `Days` date NOT NULL,
  `Allow` float(8,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`AtID`, `EmpID`, `OTHours`, `Days`, `Allow`) VALUES
(7, 3, 0, '2018-07-09', 3500.00),
(8, 5, 0, '2018-07-09', 3500.00),
(9, 4, 0, '2018-07-09', 3500.00),
(10, 6, 0, '2018-07-09', 3500.00),
(11, 7, 0, '2018-07-09', 3500.00),
(12, 8, 0, '2018-07-09', 3500.00),
(13, 9, 0, '2018-07-09', 3500.00),
(14, 10, 0, '2018-07-09', 3500.00),
(15, 11, 0, '2018-07-09', 3500.00),
(16, 12, 0, '2018-07-09', 3500.00),
(17, 13, 0, '2018-07-09', 3500.00),
(18, 14, 0, '2018-07-09', 3500.00),
(19, 15, 0, '2018-07-09', 3500.00),
(20, 29, 0, '2018-07-09', 3500.00),
(21, 16, 0, '2018-07-09', 3500.00),
(22, 28, 0, '2018-07-09', 3500.00),
(23, 27, 0, '2018-07-09', 3500.00),
(24, 17, 0, '2018-07-09', 3500.00),
(25, 18, 0, '2018-07-09', 3500.00),
(26, 19, 0, '2018-07-09', 3500.00),
(27, 20, 0, '2018-07-09', 3500.00),
(28, 21, 0, '2018-07-09', 3500.00),
(29, 22, 0, '2018-07-09', 3500.00),
(30, 23, 0, '2018-07-09', 3500.00),
(31, 24, 0, '2018-07-09', 3500.00),
(32, 25, 0, '2018-07-09', 3500.00),
(33, 26, 0, '2018-07-09', 3500.00);

-- --------------------------------------------------------

--
-- Table structure for table `employee`
--

CREATE TABLE `employee` (
  `EmpID` int(11) NOT NULL,
  `Name` varchar(40) NOT NULL,
  `NIC` varchar(10) NOT NULL,
  `Gender` varchar(1) NOT NULL,
  `Contact1` varchar(10) NOT NULL,
  `Contact2` varchar(10) DEFAULT NULL,
  `No` varchar(10) NOT NULL,
  `Street` varchar(30) NOT NULL,
  `Town` varchar(25) NOT NULL,
  `Department` varchar(20) NOT NULL,
  `Designation` varchar(20) NOT NULL,
  `JoinDate` date NOT NULL,
  `Basic` float(9,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `employee`
--

INSERT INTO `employee` (`EmpID`, `Name`, `NIC`, `Gender`, `Contact1`, `Contact2`, `No`, `Street`, `Town`, `Department`, `Designation`, `JoinDate`, `Basic`) VALUES
(1, 'A.V.D.T .R KUMARA', '950110875V', 'M', '0765289845', '0785922200', '28/1  ', 'New Nuge Rd', 'Peliyagoda', 'Office', 'Admin', '2010-11-18', 66000.00),
(2, 'J.L.D.A.KAMINI WIJEGUNASEKARA', '657025983V', 'M', '0775745555', '', '445 1/2  ', 'Colombo Rd Pepiliyana', 'Boralesgamuwa', 'Office', 'Admin', '2010-08-09', 66000.00),
(3, 'I.G MITHRAPALA', '780123456V', 'M', '0115730863', '0712111389', '575  ', 'Nawala Rd', 'Rajagiriya', 'Production', 'Driver', '2009-07-21', 16100.00),
(4, 'U.PALITHA JAYAWICKRAMA', '691203478V', 'M', '0112635512', '0784158641', '654/5', 'Industrial Zone Galle Rd ', 'Rathmalana', 'Production', 'Labour', '2011-12-09', 16100.00),
(5, 'M.AJITH MUNASINGHE ', '764152674V', 'M', '0722820824', '', '213 ', 'Colombo Rd Weligampitiya ', 'Ja-Ela', 'Production', 'Driver', '2010-02-27', 16100.00),
(6, 'G.A CHANDRANANDA ', '654231897V', 'M', '0762517722', '0112456852', '379 ', 'Galle Rd ', 'Mount Lavinia', 'Production', 'Labour', '2010-07-09', 16100.00),
(7, 'K.A.D.S.A. KATHRIARACHCHI', '894155220V', 'M', '0117203052', '0714009828', '224 ', 'High Level Rd ', 'Nugegoda', 'Finance', 'Account Assistant', '2012-05-25', 29500.00),
(8, 'H.D.D.A KUMARA ', '894516287V', 'M', '0777397400', '0112963319', '404/1G ', 'Makola North ', 'Makola', 'Production', 'Driver', '2016-01-28', 16100.00),
(9, 'R.D.R. WEERASINGHE ', '894784523V', 'M', '0762726701', '', '83A ', 'Negombo Road ', 'Wattala', 'Production', 'Labour', '2009-09-09', 16100.00),
(10, 'D.S.R.WIJESOORIYA ', '651234852V', 'M', '0777831589', '0114334644', '282 ', 'Colombo Rd Divulapitiya ', 'Boralesgamuwa', 'Production', 'Labour', '2010-07-28', 16100.00),
(11, 'N.A.SIRIMANNA ', '764589921V', 'M', '0714588612', '0112564371', '399 ', 'Galle Rd ', 'Colombo 03', 'Production', 'Labour', '2010-03-11', 16100.00),
(12, 'H.H.D.NISHANTHA ', '681257368V', 'M', '0332291915', '0714131402', '88/2 ', 'Mahawita ', 'Yakkala', 'Production', 'Labour', '2009-05-20', 16100.00),
(13, 'K.K.JAYANTHA ', '901255584V', 'M', '0779400586', '', '43 ', 'Rajagiriya Road ', 'Rajagiriya', 'Production', 'Labour', '2008-07-10', 16100.00),
(14, 'R.P.S.KUMARA ', '957845113V', 'M', '0112810538', '0777585670', '113 ', 'Horana Rd Kesbewa ', 'Piliyandala', 'Production', 'Site supervisor', '2011-03-29', 39500.00),
(15, 'D. H. WICKRAMASINGHE ', '782654569V', 'M', '0785522496', '', '32 ', 'Kandy Rd Tyre Junction ', 'Kelaniya', 'Production', 'Site supervisor', '2018-07-01', 23500.00),
(16, 'THILAKARATHNA KOTHALAWALA ', '795628497V', 'M', '0772616727', '0112742848', '279/15B ', 'Godagama Rd ', 'Athurugiriya', 'Production', 'Driver', '2010-10-06', 16100.00),
(17, 'THILAK HETTIGE ', '841285492V', 'M', '0784863614', '', '35B ', 'Old Kottawa Rd Mirihana ', 'Nugegoda', 'Production', 'Helper Driver', '2013-06-11', 16100.00),
(18, 'B.WIJITHA ', '751249526V', 'M', '0778602866', '', ' 335 ', 'Nawala (Rajagiriya) Rd ', 'Nawala', 'Production', 'Labour', '2013-07-08', 16100.00),
(19, 'R.M WIJESIRI ', '861458852V', 'M', '0767807121', '0717807125', '76/7 ', 'Pahala Dompe ', 'Dompe', 'Production', 'Labour', '2010-11-02', 16100.00),
(20, 'G.SHIVAGURU ', '897441888V', 'M', '0771115112', '0776360322', '181 ', 'Nawala Rd ', 'Nugegoda', 'Production', 'Labour', '2015-02-03', 16100.00),
(21, 'M.JAWAGER ', '882144783V', 'M', '0722472640', '', '138 ', 'Sri Sangaraja Mw ', 'Colombo 10', 'Production', 'Labour', '2011-11-14', 16100.00),
(22, 'K.WASUDEWA ', '791028851V', 'M', '0712473012', '', '16', 'Athurugiriya Rd Kottawa ', 'Pannipitiya', 'Production', 'Labour', '2010-02-24', 16100.00),
(23, 'K.WIJEDARAN ', '814577909V', 'M', '0772337369', '', '401 ', 'Sri Sangaraja Mw ', 'Colombo 10', 'Production', 'Labour', '2016-07-11', 16100.00),
(24, 'M.RAVI ', '750852987V', 'M', '0712358969', '', '417 ', 'Old Moor St ', 'Colombo 11', 'Production', 'Labour', '2014-06-24', 16100.00),
(25, 'K.L RAJA ', '821955682V', 'M', '0767294431', '', '111 ', 'Colombo Rd ', 'Piliyandala', 'Production', 'Labour', '2010-02-26', 16100.00),
(26, 'V.RASI KUMAR ', '785662158V', 'M', '0782332453', '', '464P  ', 'Old Moor Street', 'Colombo 12', 'Production', 'Labour', '2011-08-19', 16100.00),
(27, 'B.JAYAKRISHNAN ', '991258885V', 'M', '0775231257', '', '941/5', 'Parliament Drive Etulkotte ', 'Kotte', 'Production', 'Labour', '2015-07-03', 16100.00),
(28, 'SATHYA SEALAN ', '782214588V', 'M', '0778608897', '', '208 ', 'Main Rd Attidiya ', 'Dehiwela', 'Production', 'Labour', '2018-06-25', 16100.00),
(29, 'SELWAMUTHTHU RAJAN ', '788845158V', 'M', '0773828900', '', 'No 121 ', 'Malay St ', 'Colombo 02', 'Production', 'Labour', '2010-05-31', 16100.00);

-- --------------------------------------------------------

--
-- Table structure for table `loanadvance`
--

CREATE TABLE `loanadvance` (
  `AdvID` int(11) NOT NULL,
  `EmpID` int(3) NOT NULL,
  `Advance` double(8,2) DEFAULT NULL,
  `Loan` double(8,2) DEFAULT NULL,
  `Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `loanadvance`
--

INSERT INTO `loanadvance` (`AdvID`, `EmpID`, `Advance`, `Loan`, `Date`) VALUES
(10, 3, 0.00, 5000.00, '2018-07-09'),
(11, 4, 2000.00, 0.00, '2018-07-09'),
(12, 5, 2900.00, 5000.00, '2018-07-09'),
(13, 6, 3000.00, 0.00, '2018-07-09'),
(14, 7, 7500.00, 5000.00, '2018-07-09'),
(15, 8, 17000.00, 5000.00, '2018-07-09'),
(16, 9, 7500.00, 5000.00, '2018-07-09'),
(17, 10, 19650.00, 5000.00, '2018-07-09'),
(18, 11, 0.00, 5000.00, '2018-07-09'),
(19, 12, 14000.00, 5000.00, '2018-07-09'),
(20, 13, 10000.00, 5000.00, '2018-07-09'),
(21, 14, 2784.00, 5000.00, '2018-07-09'),
(22, 15, 2000.00, 0.00, '2018-07-09'),
(23, 16, 4500.00, 5000.00, '2018-07-09'),
(24, 17, 7800.00, 0.00, '2018-07-09'),
(25, 18, 15500.00, 5000.00, '2018-07-09'),
(26, 19, 0.00, 5000.00, '2018-07-09'),
(27, 20, 17888.33, 0.00, '2018-07-09'),
(28, 21, 24167.50, 5000.00, '2018-07-09'),
(29, 22, 24659.72, 5000.00, '2018-07-09'),
(30, 23, 32954.14, 5000.00, '2018-07-09'),
(31, 25, 23118.06, 5000.00, '2018-07-09'),
(32, 26, 27659.72, 0.00, '2018-07-09'),
(33, 27, 28659.72, 0.00, '2018-07-09'),
(34, 28, 14113.08, 0.00, '2018-07-09'),
(35, 29, 14113.08, 0.00, '2018-07-09');

-- --------------------------------------------------------

--
-- Table structure for table `login`
--

CREATE TABLE `login` (
  `ID` int(4) NOT NULL,
  `UserName` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Designation` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login`
--

INSERT INTO `login` (`ID`, `UserName`, `Password`, `Designation`) VALUES
(2, '1', '1', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `salary`
--

CREATE TABLE `salary` (
  `SalID` int(3) NOT NULL,
  `EmpID` int(3) NOT NULL,
  `Days` int(2) DEFAULT NULL,
  `NoPay` double(8,2) DEFAULT NULL,
  `OTPay` double(8,2) DEFAULT NULL,
  `EPF8` double(8,2) NOT NULL,
  `EPF12` double(8,2) NOT NULL,
  `ETF3` double(8,2) NOT NULL,
  `ProductIns` double(8,2) DEFAULT NULL,
  `TravelIns` double(8,2) DEFAULT NULL,
  `Final` double(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `salary`
--

INSERT INTO `salary` (`SalID`, `EmpID`, `Days`, `NoPay`, `OTPay`, `EPF8`, `EPF12`, `ETF3`, `ProductIns`, `TravelIns`, `Final`) VALUES
(1, 1, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 66000.00),
(2, 2, 0, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 0.00, 66000.00),
(3, 3, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -6568.00),
(4, 4, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -9940.00, 0.00, 6092.00),
(5, 5, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -9468.00),
(6, 6, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -740.01, 0.00, 14291.99),
(7, 7, 0, 0.00, 0.00, 2640.00, 3960.00, 990.00, 0.00, 0.00, 17860.00),
(8, 8, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -23568.00),
(9, 9, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -10290.00, 0.00, -4758.00),
(10, 10, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -1430.01, 0.00, -8048.01),
(11, 11, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -6568.00),
(12, 12, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -3970.00, 0.00, -4938.00),
(13, 13, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -8890.00, 0.00, -5858.00),
(14, 14, 0, 0.00, 0.00, 3440.00, 5160.00, 1290.00, 0.00, 0.00, 31776.00),
(15, 15, 0, 0.00, 0.00, 2160.00, 3240.00, 810.00, 0.00, 0.00, 22840.00),
(16, 16, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -11068.00),
(17, 17, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -9368.00),
(18, 18, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -3830.00, 0.00, -6298.00),
(19, 19, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -14850.00, 0.00, -1818.00),
(20, 20, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 579.99, 0.00, 723.66),
(21, 21, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 16492.50, 0.00, 5357.00),
(22, 22, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 14751.38, 0.00, 3123.66),
(23, 23, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 26366.64, 0.00, 6444.50),
(24, 24, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -19600.00, 0.00, -1568.00),
(25, 25, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 13659.72, 0.00, 3573.66),
(26, 26, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 20651.38, 0.00, 11023.66),
(27, 27, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 13601.38, 0.00, 2973.66),
(28, 28, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, 8154.74, 0.00, 12073.66),
(29, 29, 0, 0.00, 0.00, 1568.00, 2352.00, 588.00, -4436.00, 0.00, -517.08);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`AtID`),
  ADD KEY `at_frgn` (`EmpID`);

--
-- Indexes for table `employee`
--
ALTER TABLE `employee`
  ADD PRIMARY KEY (`EmpID`);

--
-- Indexes for table `loanadvance`
--
ALTER TABLE `loanadvance`
  ADD PRIMARY KEY (`AdvID`),
  ADD KEY `loan_frgn` (`EmpID`);

--
-- Indexes for table `login`
--
ALTER TABLE `login`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `salary`
--
ALTER TABLE `salary`
  ADD PRIMARY KEY (`SalID`),
  ADD UNIQUE KEY `EmpID` (`EmpID`),
  ADD UNIQUE KEY `SalID` (`SalID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
  MODIFY `AtID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;

--
-- AUTO_INCREMENT for table `loanadvance`
--
ALTER TABLE `loanadvance`
  MODIFY `AdvID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=36;

--
-- AUTO_INCREMENT for table `login`
--
ALTER TABLE `login`
  MODIFY `ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `attendance`
--
ALTER TABLE `attendance`
  ADD CONSTRAINT `at_frgn` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE CASCADE;

--
-- Constraints for table `loanadvance`
--
ALTER TABLE `loanadvance`
  ADD CONSTRAINT `loan_frgn` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE CASCADE;

--
-- Constraints for table `salary`
--
ALTER TABLE `salary`
  ADD CONSTRAINT `salary_ibfk_1` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE CASCADE,
  ADD CONSTRAINT `salary_ibfk_2` FOREIGN KEY (`EmpID`) REFERENCES `employee` (`EmpID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
