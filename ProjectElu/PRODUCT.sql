/*
Navicat SQLite Data Transfer

Source Server         : 1
Source Server Version : 30706
Source Host           : :0

Target Server Type    : SQLite
Target Server Version : 30706
File Encoding         : 65001

Date: 2015-04-18 10:56:40
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
PRIMARY KEY ("ID" ASC),
CONSTRAINT "1" FOREIGN KEY ("Unit") REFERENCES "USER" ("UNIT")
);

-- ----------------------------
-- Records of PRODUCT
-- ----------------------------
INSERT INTO "main"."PRODUCT" VALUES (0, 'Y', 1, null, null, null, null, null);
