/*
 Navicat Premium Data Transfer

 Source Server         : xampp
 Source Server Type    : MariaDB
 Source Server Version : 100408
 Source Host           : localhost:3306
 Source Schema         : buyfuture

 Target Server Type    : MariaDB
 Target Server Version : 100408
 File Encoding         : 65001

 Date: 15/07/2020 11:02:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for price
-- ----------------------------
DROP TABLE IF EXISTS `price`;
CREATE TABLE `price`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `stock_no` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `time` datetime(0) NULL DEFAULT NULL,
  `price` decimal(10, 2) NULL DEFAULT NULL,
  `buy` decimal(10, 2) NULL DEFAULT NULL,
  `sell` decimal(10, 2) NULL DEFAULT NULL,
  `up_down` decimal(10, 2) NULL DEFAULT NULL,
  `volume` decimal(10, 2) NULL DEFAULT NULL,
  `close` decimal(10, 2) NULL DEFAULT NULL,
  `open` decimal(10, 2) NULL DEFAULT NULL,
  `high` decimal(10, 2) NULL DEFAULT NULL,
  `low` decimal(10, 2) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 56 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of price
-- ----------------------------
INSERT INTO `price` VALUES (2, '1101 台泥', '2020-07-10 12:42:00', 45.10, 45.05, 45.10, 0.20, 13662.00, 45.30, 45.30, 45.35, 45.00);
INSERT INTO `price` VALUES (3, '1101B 台泥乙特', '2020-07-10 12:26:00', 54.50, 54.50, 55.00, 0.50, 101.00, 55.00, 54.50, 54.50, 54.50);
INSERT INTO `price` VALUES (4, '1102 亞泥', '2020-07-10 12:42:00', 46.35, 46.30, 46.35, 0.30, 8913.00, 46.05, 46.20, 46.70, 46.00);
INSERT INTO `price` VALUES (5, '1103 嘉泥', '2020-07-10 12:37:00', 17.95, 17.95, 18.00, 0.25, 977.00, 18.20, 18.20, 18.20, 17.85);
INSERT INTO `price` VALUES (6, '1104 環泥', '2020-07-10 12:40:00', 18.25, 18.25, 18.30, 0.05, 654.00, 18.30, 18.30, 18.30, 18.10);
INSERT INTO `price` VALUES (7, '1108 幸福', '2020-07-10 12:39:00', 9.95, 9.95, 9.96, 0.01, 302.00, 9.96, 10.10, 10.10, 9.95);
INSERT INTO `price` VALUES (8, '1109 信大', '2020-07-10 12:32:00', 18.20, 18.15, 18.25, 0.25, 149.00, 18.45, 18.35, 18.35, 18.10);
INSERT INTO `price` VALUES (9, '1110 東泥', '2020-07-10 11:13:00', 16.15, 16.10, 16.20, 0.20, 21.00, 16.35, 16.35, 16.35, 16.10);
INSERT INTO `price` VALUES (10, '1201 味全', '2020-07-10 12:45:00', 22.75, 22.70, 22.75, 0.30, 1578.00, 23.05, 23.05, 23.10, 22.60);
INSERT INTO `price` VALUES (11, '1203 味王', '2020-07-10 12:33:00', 29.70, 29.70, 29.80, 0.15, 20.00, 29.85, 29.85, 29.85, 29.65);
INSERT INTO `price` VALUES (12, '1210 大成', '2020-07-10 12:46:00', 44.00, 44.00, 44.05, 0.05, 1658.00, 44.05, 44.10, 44.15, 43.60);
INSERT INTO `price` VALUES (13, '1213 大飲', '2020-07-10 10:10:00', 5.90, 6.01, 6.26, 0.15, 1.00, 6.05, 5.90, 5.90, 5.90);
INSERT INTO `price` VALUES (14, '1215 卜蜂', '2020-07-10 12:44:00', 68.00, 68.00, 68.10, 0.00, 756.00, 68.00, 68.10, 68.20, 67.40);
INSERT INTO `price` VALUES (15, '1216 統一', '2020-07-10 12:46:00', 73.70, 73.60, 73.70, 0.20, 6499.00, 73.50, 73.40, 73.80, 72.60);
INSERT INTO `price` VALUES (16, '1217 愛之味', '2020-07-10 12:41:00', 7.43, 7.42, 7.43, 0.05, 1436.00, 7.48, 7.46, 7.50, 7.38);
INSERT INTO `price` VALUES (17, '1218 泰山', '2020-07-10 12:43:00', 23.70, 23.65, 23.70, 0.05, 1298.00, 23.65, 23.80, 23.85, 23.60);
INSERT INTO `price` VALUES (18, '1219 福壽', '2020-07-10 12:45:00', 20.40, 20.40, 20.55, 0.30, 119.00, 20.70, 20.85, 20.85, 20.40);
INSERT INTO `price` VALUES (19, '1220 台榮', '2020-07-10 12:41:00', 11.35, 11.30, 11.35, 0.05, 261.00, 11.40, 11.40, 11.45, 11.30);
INSERT INTO `price` VALUES (20, '1225 福懋油', '2020-07-10 12:44:00', 37.65, 37.60, 37.85, 1.05, 121.00, 38.70, 38.70, 38.70, 37.60);
INSERT INTO `price` VALUES (21, '1227 佳格', '2020-07-10 12:45:00', 66.40, 66.40, 66.50, 0.00, 938.00, 66.40, 66.90, 66.90, 65.20);
INSERT INTO `price` VALUES (22, '1229 聯華', '2020-07-10 12:45:00', 43.10, 43.05, 43.10, 0.50, 2064.00, 43.60, 43.60, 43.60, 42.90);
INSERT INTO `price` VALUES (23, '1231 聯華食', '2020-07-10 12:41:00', 43.65, 43.55, 43.65, 0.35, 266.00, 44.00, 44.00, 44.00, 43.15);
INSERT INTO `price` VALUES (24, '1232 大統益', '2020-07-10 12:45:00', 121.00, 121.00, 121.50, 1.00, 92.00, 122.00, 122.00, 122.00, 120.50);
INSERT INTO `price` VALUES (25, '1233 天仁', '2020-07-10 12:44:00', 36.80, 36.80, 36.90, 0.15, 74.00, 36.65, 36.65, 36.80, 36.40);
INSERT INTO `price` VALUES (26, '1234 黑松', '2020-07-10 12:36:00', 34.15, 34.05, 34.15, 0.00, 152.00, 34.15, 34.30, 34.35, 33.90);
INSERT INTO `price` VALUES (27, '1235 興泰', '2020-07-10 12:15:00', 27.35, 27.35, 27.65, 0.65, 25.00, 28.00, 28.00, 28.00, 27.20);
INSERT INTO `price` VALUES (28, '1236 宏亞', '2020-07-10 12:07:00', 13.00, 13.00, 13.10, 0.25, 32.00, 13.25, 13.20, 13.30, 12.95);
INSERT INTO `price` VALUES (29, '1256 鮮活果汁-KY', '2020-07-10 12:21:00', 212.50, 212.00, 213.00, 2.50, 25.00, 215.00, 214.50, 214.50, 211.00);
INSERT INTO `price` VALUES (30, '1702 南僑', '2020-07-10 12:45:00', 44.35, 44.35, 44.40, 0.75, 368.00, 45.10, 45.20, 45.20, 44.00);
INSERT INTO `price` VALUES (31, '1737 臺鹽', '2020-07-10 12:44:00', 31.50, 31.50, 31.55, 0.10, 740.00, 31.60, 31.60, 31.65, 31.40);
INSERT INTO `price` VALUES (32, '1708 東鹼', '2020-07-10 12:45:00', 23.90, 23.85, 23.90, 0.45, 889.00, 24.35, 24.35, 24.35, 23.75);
INSERT INTO `price` VALUES (33, '1709 和益', '2020-07-10 12:43:00', 13.55, 13.55, 13.60, 0.20, 2461.00, 13.75, 13.75, 14.20, 13.45);
INSERT INTO `price` VALUES (34, '1710 東聯', '2020-07-10 12:45:00', 16.80, 16.80, 16.85, 0.20, 1603.00, 17.00, 17.00, 17.00, 16.80);
INSERT INTO `price` VALUES (35, '1711 永光', '2020-07-10 12:45:00', 17.70, 17.65, 17.70, 0.30, 7012.00, 18.00, 18.00, 18.00, 17.00);
INSERT INTO `price` VALUES (36, '1712 興農', '2020-07-10 12:45:00', 18.40, 18.35, 18.45, 0.05, 1968.00, 18.35, 18.40, 18.60, 18.30);
INSERT INTO `price` VALUES (37, '1713 國化', '2020-07-10 12:38:00', 17.80, 17.75, 17.80, 0.25, 53.00, 18.05, 18.05, 18.05, 17.75);
INSERT INTO `price` VALUES (38, '1714 和桐', '2020-07-10 12:46:00', 7.84, 7.83, 7.84, 0.02, 4307.00, 7.82, 7.85, 7.88, 7.64);
INSERT INTO `price` VALUES (39, '1717 長興', '2020-07-10 12:45:00', 32.25, 32.20, 32.25, 1.60, 9074.00, 33.85, 33.95, 34.00, 32.05);
INSERT INTO `price` VALUES (40, '1718 中纖', '2020-07-10 12:44:00', 6.57, 6.57, 6.58, 0.16, 3397.00, 6.73, 6.70, 6.71, 6.53);
INSERT INTO `price` VALUES (41, '1721 三晃', '2020-07-10 12:40:00', 9.73, 9.71, 9.75, 0.14, 310.00, 9.87, 9.80, 9.80, 9.67);
INSERT INTO `price` VALUES (42, '1722 台肥', '2020-07-10 12:45:00', 57.00, 56.90, 57.00, 0.10, 7814.00, 57.10, 57.50, 57.90, 55.50);
INSERT INTO `price` VALUES (43, '1723 中碳', '2020-07-10 12:33:00', 106.50, 106.00, 106.50, 1.00, 518.00, 107.50, 107.00, 107.00, 105.00);
INSERT INTO `price` VALUES (44, '1724 台硝', '2020-07-10 12:33:00', 12.90, 12.90, 13.00, 0.05, 30.00, 12.95, 13.10, 13.10, 12.90);
INSERT INTO `price` VALUES (45, '1725 元禎', '2020-07-10 12:06:00', 14.50, 14.50, 14.55, 0.05, 9.00, 14.55, 14.60, 14.60, 14.35);
INSERT INTO `price` VALUES (46, '1726 永記', '2020-07-10 11:41:00', 70.10, 70.00, 70.50, 0.20, 34.00, 70.30, 70.30, 70.70, 69.00);
INSERT INTO `price` VALUES (47, '1727 中華化', '2020-07-10 12:42:00', 9.60, 9.54, 9.60, 0.03, 44.00, 9.57, 9.58, 9.60, 9.53);
INSERT INTO `price` VALUES (48, '1730 花仙子', '2020-07-10 12:44:00', 74.70, 74.70, 74.80, 0.80, 123.00, 75.50, 76.40, 76.40, 73.80);
INSERT INTO `price` VALUES (49, '1732 毛寶', '2020-07-10 12:45:00', 28.30, 28.25, 28.35, 0.50, 1868.00, 27.80, 28.00, 29.15, 27.85);
INSERT INTO `price` VALUES (50, '1735 日勝化', '2020-07-10 11:54:00', 16.65, 16.60, 16.85, 0.05, 1.00, 16.70, 16.65, 16.65, 16.65);
INSERT INTO `price` VALUES (51, '1773 勝一', '2020-07-10 12:46:00', 108.00, 108.00, 108.50, 4.00, 1147.00, 112.00, 112.00, 112.50, 106.50);
INSERT INTO `price` VALUES (52, '1776 展宇', '2020-07-10 11:48:00', 17.15, 17.05, 17.20, 0.15, 28.00, 17.30, 17.40, 17.50, 17.00);
INSERT INTO `price` VALUES (53, '3708 上緯投控', '2020-07-10 12:46:00', 95.70, 95.60, 95.90, 1.60, 3664.00, 97.30, 97.20, 99.30, 93.00);
INSERT INTO `price` VALUES (54, '4720 德淵', '2020-07-10 12:45:00', 14.45, 14.45, 14.50, 0.30, 6462.00, 14.15, 14.20, 14.75, 13.60);
INSERT INTO `price` VALUES (55, '4722 國精化', '2020-07-10 12:44:00', 25.40, 25.40, 25.50, 0.20, 76.00, 25.60, 25.60, 25.60, 25.25);

-- ----------------------------
-- Table structure for stock
-- ----------------------------
DROP TABLE IF EXISTS `stock`;
CREATE TABLE `stock`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `code` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `name` varchar(32) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `code`(`code`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of stock
-- ----------------------------
INSERT INTO `stock` VALUES (1, '1001', '台泥');

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  `pwd` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES (1, '王小明', '1234');
INSERT INTO `user` VALUES (2, '小豬', '3333');

-- ----------------------------
-- Table structure for user_stock
-- ----------------------------
DROP TABLE IF EXISTS `user_stock`;
CREATE TABLE `user_stock`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user_id` int(11) NULL DEFAULT NULL,
  `stock_id` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE,
  INDEX `fk_user_id`(`user_id`) USING BTREE,
  INDEX `fk_stock_id`(`stock_id`) USING BTREE,
  CONSTRAINT `fk_stock_id` FOREIGN KEY (`stock_id`) REFERENCES `stock` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_user_id` FOREIGN KEY (`user_id`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE = InnoDB AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of user_stock
-- ----------------------------
INSERT INTO `user_stock` VALUES (1, 1, 1);
INSERT INTO `user_stock` VALUES (2, 2, 1);

SET FOREIGN_KEY_CHECKS = 1;
