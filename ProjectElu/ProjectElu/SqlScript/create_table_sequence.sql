/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 10:53:54
*/
-- ----------------------------
-- Table structure for "main"."PRODUCT"
-- ----------------------------
DROP TABLE "main"."PRODUCT";
CREATE TABLE "PRODUCT" (
"ID"  VARCHAR2(36) NOT NULL,
"NAME"  VARCHAR2(16),
"Unit"  VARCHAR2(64),
"Department"  VARCHAR2(64),
"Instrument"  VARCHAR2(16),
"Contacts"  VARCHAR2(16),
"Phone"  VARCHAR2(16),
"Starttime"  DATETIME,
PRIMARY KEY ("ID")
);


-- ----------------------------
-- Table structure for "main"."ROLE"
-- ----------------------------
DROP TABLE "main"."ROLE";
CREATE TABLE "ROLE" (
"RoleID"  INTEGER NOT NULL,
"Descripe"  VARCHAR2(16)
PRIMARY KEY ("ID")
);

-- ----------------------------
-- Records of ROLE
-- ----------------------------
INSERT INTO "main"."ROLE" VALUES (0, '超级管理员');
INSERT INTO "main"."ROLE" VALUES (1, '部门管理员');
INSERT INTO "main"."ROLE" VALUES (2, '部门用户');

-- ----------------------------
-- Table structure for "main"."USER"
-- ----------------------------
DROP TABLE "main"."USER";
CREATE TABLE "USER" (
"ID"  VARCHAR2(36) NOT NULL,
"USERNAME"  VARCHAR2(36),
"PASSWORD"  VARCHAR2(64),
"ROLETYPE"  INTEGER,
"UNIT"  VARCHAR2(64),
PRIMARY KEY ("ID")
);

-- ----------------------------
-- Records of USER
-- ----------------------------
INSERT INTO "main"."USER" VALUES ('e756bf3cbe4d48e8a4159b6cc2f40998', 'admin', '21232F297A57E382A743E5A1890E4AE282AC1F3F', 0, '总管理员');
INSERT INTO "main"."USER" VALUES ('de7e450ad4ff40258900b971a6d48783', 'user1', '氖B8牴#?蘌歰u剾', 0, '单位1');
INSERT INTO "main"."USER" VALUES ('8b68d2370db44d57af0b12fd999df8fb', 'user2', '氖B8牴#?蘌歰u剾', 0, '单位2');