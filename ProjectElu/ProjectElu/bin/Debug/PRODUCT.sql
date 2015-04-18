/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 16:03:29
*/

PRAGMA foreign_keys = OFF;

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
PRIMARY KEY ("ID" ASC)
);

-- ----------------------------
-- Records of PRODUCT
-- ----------------------------
INSERT INTO "main"."PRODUCT" VALUES ('7c5f6afe3f4c48e8a206faeeb93bdc23', null, '单位1', '财务部', '电脑', '张三', 13843215687, '2011-10-13');
INSERT INTO "main"."PRODUCT" VALUES ('61577dc2ef064321a57384a558db2652', null, '单位1', '人事部', '投影仪', '李四', 15923529853, '2013-8-2');
INSERT INTO "main"."PRODUCT" VALUES ('ca085b30571b4fa994d6f4bcc916b2ba', null, '单位2', '研发部', '电脑', '王五', 13589347458, '2011-9-9');
INSERT INTO "main"."PRODUCT" VALUES ('7f0807f02dcb4029968b12d2b1724ae8', null, '单位2', '销售部', '投影仪', '赵六', 13578438543, '2012-3-1');
