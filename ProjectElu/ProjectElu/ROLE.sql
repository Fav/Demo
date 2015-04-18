/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 10:55:15
*/

PRAGMA foreign_keys = OFF;

-- ----------------------------
-- Table structure for "main"."ROLE"
-- ----------------------------
DROP TABLE "main"."ROLE";
CREATE TABLE "ROLE" (
"RoleID"  INTEGER NOT NULL,
"Descripe"  VARCHAR2(16)
);

-- ----------------------------
-- Records of ROLE
-- ----------------------------
INSERT INTO "main"."ROLE" VALUES (0, '超级管理员');
INSERT INTO "main"."ROLE" VALUES (1, '部门管理员');
INSERT INTO "main"."ROLE" VALUES (2, '部门用户');
