-- Create the database
CREATE DATABASE library;

-- Switch to the newly created database
USE library;

-- Create the books table
CREATE TABLE books (
    book_id INT AUTO_INCREMENT PRIMARY KEY,
    author_id INT NOT NULL DEFAULT 0,
    title VARCHAR(55) NOT NULL,
    isbn VARCHAR(25) NOT NULL,
    pub_year SMALLINT NOT NULL,
    available TINYINT NOT NULL DEFAULT 0
);

-- Insert 10 sample rows of data
INSERT INTO books (author_id, title, isbn, pub_year, available)
VALUES
    (1, 'The Great Gatsby', '978-0-7432-7356-5', 1925, 1),
    (2, 'To Kill a Mockingbird', '0-06-112008-1', 1960, 1),
    (3, 'Twenty Thousand Leagues Under the Sea', '978-0-452-28423-4', 1949, 1),
    (4, 'Pride and Prejudice', '978-1-59308-324-0', 1813, 1),
    (5, 'The Catcher in the Rye', '978-0-316-76948-7', 1951, 0),
    (6, 'Lord of the Rings', '978-0-618-26030-7', 1954, 1),
    (7, 'Harry Potter and the Sorcerer\'s Stone', '0-590-35340-3', 1997, 1),
    (8, 'The Hobbit', '978-0-618-34625-4', 1937, 1),
    (9, 'Fahrenheit 451', '978-1-9821-6636-5', 1953, 1),
    (10, 'Brave New World', '978-0-06-092987-9', 1932, 0);