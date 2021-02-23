USE boisecodeworks;

CREATE TABLE kitBricks
(
  id INT AUTO_INCREMENT,
  kitId INT,
  brickId INT,

  PRIMARY KEY(id),

  FOREIGN KEY (kitId)
    REFERENCES kits (id)
    ON DELETE CASCADE,

  FOREIGN KEY (brickId)
    REFERENCES bricks (id)
    ON DELETE CASCADE
)

-- DROP TABLE bricks;

-- CREATE TABLE bricks 
-- (
--   id INT AUTO_INCREMENT,
--   name VARCHAR(255),
--   color VARCHAR(255),
--   studWidth VARCHAR(255),
--   studHeight VARCHAR(255),

--   PRIMARY KEY(id)
-- )

-- DROP TABLE kits;

-- CREATE TABLE kits
-- (
--   id INT AUTO_INCREMENT,
--   price DECIMAL(5,2),
--   instructions VARCHAR(255),
--   name VARCHAR(255),

--   PRIMARY KEY(id)
-- )