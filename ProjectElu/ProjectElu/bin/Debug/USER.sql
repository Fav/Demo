/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 14:35:45
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
INSERT INTO "main"."USER" VALUES ('e756bf3cbe4d48e8a4159b6cc2f40998', 'admin', X'21232F297A57E382A743E5A1890E4AE282AC1F3F', 0, '总管理员');
INSERT INTO "main"."USER" VALUES ('de7e450ad4ff40258900b971a6d48783', 'user1', '氖B8牴#?蘌歰u剾', 0, '单位1');
INSERT INTO "main"."USER" VALUES ('8b68d2370db44d57af0b12fd999df8fb', 'user2', '氖B8牴#?蘌歰u剾', 0, '单位2');
