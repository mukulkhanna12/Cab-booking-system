-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 16, 2018 at 08:31 AM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cab`
--

-- --------------------------------------------------------

--
-- Table structure for table `cars`
--

CREATE TABLE `cars` (
  `cid` int(10) NOT NULL,
  `cno` varchar(30) NOT NULL,
  `name` varchar(30) NOT NULL,
  `phoneno` double NOT NULL,
  `price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `cars`
--

INSERT INTO `cars` (`cid`, `cno`, `name`, `phoneno`, `price`) VALUES
(1, 'Dl 3C AB 4411', 'Alix Knott', 9819293456, 100),
(2, 'Dl 4C BC 5522', 'Jennie Cope', 9999123467, 200),
(3, 'Dl 5C CD 6633', 'Jean Bloom', 9876123456, 300),
(4, 'Dl 6C CE 7744', 'Tess Corbett', 9875674123, 400);

-- --------------------------------------------------------

--
-- Table structure for table `complaints`
--

CREATE TABLE `complaints` (
  `id` int(10) NOT NULL,
  `name` varchar(20) NOT NULL,
  `complain` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `complaints`
--

INSERT INTO `complaints` (`id`, `name`, `complain`) VALUES
(1, 'Jennie Cope', 'Breaking Rules'),
(2, 'Jennie Cope', 'Breaking Rules'),
(3, 'Alix Knott', 'Fast Driving'),
(4, 'Tess Corbett', 'Dirty Car Environmen'),
(5, 'Jennie Cope', 'Wrong Dressing Sense'),
(6, 'Jennie Cope', 'Breaking Rules');

-- --------------------------------------------------------

--
-- Table structure for table `place`
--

CREATE TABLE `place` (
  `id` int(10) NOT NULL,
  `place` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `place`
--

INSERT INTO `place` (`id`, `place`) VALUES
(1, 'Dilshad Garden'),
(2, 'Jhilmil'),
(3, 'Mansrover park'),
(4, 'Shahdara'),
(5, 'Welcome'),
(6, 'Seelam Pur'),
(7, 'Shastri Park'),
(8, 'Kashmere Gate'),
(9, 'Tis Hazari'),
(10, 'Pul Bangash'),
(11, 'Pratap Nagar'),
(12, 'Shastri Nagar'),
(13, 'Inder Lok'),
(14, 'Kanhaiya Nagar'),
(15, 'Keshav Puram'),
(16, 'Netaji Subash Place'),
(17, 'Kohat Enclave'),
(18, 'Pitam Pura'),
(19, 'RohiniEast'),
(20, 'Rohini West'),
(21, 'Rithala');

-- --------------------------------------------------------

--
-- Table structure for table `trip`
--

CREATE TABLE `trip` (
  `id` int(10) NOT NULL,
  `uid` int(10) NOT NULL,
  `cid` int(10) NOT NULL,
  `start` varchar(20) NOT NULL,
  `end` varchar(20) NOT NULL,
  `amount` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `trip`
--

INSERT INTO `trip` (`id`, `uid`, `cid`, `start`, `end`, `amount`) VALUES
(1, 1, 2, 'Mansrover park', 'Tis Hazari', 200),
(2, 1, 2, 'Pratap Nagar', 'Rithala', 200),
(3, 1, 4, 'Shahdara', 'Rithala', 400),
(4, 2, 2, 'Dilshad Garden', 'Pratap Nagar', 200),
(5, 2, 1, 'Shahdara', 'Tis Hazari', 100),
(6, 2, 2, 'Shahdara', 'Pul Bangash', 200),
(7, 2, 2, 'Shastri Park', 'Rithala', 300),
(8, 2, 2, 'Kashmere Gate', 'Rithala', 300),
(9, 1, 1, 'Kashmere Gate', 'Mansrover park', 100),
(10, 3, 2, 'Jhilmil', 'Tis Hazari', 200),
(11, 1, 2, 'Jhilmil', 'Pratap Nagar', 200),
(12, 1, 3, 'Welcome', 'Pitam Pura', 300),
(13, 1, 1, 'Jhilmil', 'Seelam Pur', 100),
(14, 1, 1, 'Jhilmil', 'Seelam Pur', 100);

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(10) NOT NULL,
  `name` varchar(100) NOT NULL,
  `email` varchar(100) NOT NULL,
  `pass` varchar(30) NOT NULL,
  `phone` int(10) NOT NULL,
  `gender` varchar(100) NOT NULL,
  `wallet` int(10) NOT NULL DEFAULT '1000'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `email`, `pass`, `phone`, `gender`, `wallet`) VALUES
(1, 'Rohit', 'rohit@mail.com', 'rohit', 2147483647, 'male', 1300),
(2, 'kshitij', 'kshitij@mail.com', 'kshitij', 2147483647, 'male', 300),
(3, 'asim', 'asim@mail.com', '1234', 987654321, 'male', 800),
(4, 'asim', 'asim@mail.com', '1234', 987654321, 'male', 1000),
(5, 'asim', 'asim@mail.com', '1234', 987654321, 'male', 1000),
(6, 'asim', 'asim@mail.com', '1234', 987654321, 'male', 1000);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `cars`
--
ALTER TABLE `cars`
  ADD PRIMARY KEY (`cid`);

--
-- Indexes for table `complaints`
--
ALTER TABLE `complaints`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `place`
--
ALTER TABLE `place`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `trip`
--
ALTER TABLE `trip`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `cars`
--
ALTER TABLE `cars`
  MODIFY `cid` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `complaints`
--
ALTER TABLE `complaints`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
--
-- AUTO_INCREMENT for table `place`
--
ALTER TABLE `place`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;
--
-- AUTO_INCREMENT for table `trip`
--
ALTER TABLE `trip`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
