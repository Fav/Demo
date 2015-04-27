/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 10:55:22
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."USER"
-- ----------------------------
DROP TABLE "main"."USER";
CREATE TABLE "USER" (
"ID"  VARCHAR2(36),
"USERNAME"  VARCHAR2(36),
"PASSWORD"  VARCHAR2(64),
"ROLETYPE"  INTEGER,
"UNIT"  VARCHAR2(64),
PRIMARY KEY ("ID")
);

-- ----------------------------
-- Records of USER
-- ----------------------------
