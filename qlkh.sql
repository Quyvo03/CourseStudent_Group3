CREATE DATABASE QLKHoc;
GO
USE QLKHoc;
GO
-- Tạo bảng users
CREATE TABLE Users (
    user_id INT PRIMARY KEY ,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    Email VARCHAR(50) NOT NULL,
	Phone nchar(10) not null,
	Detail VARCHAR(50) not null,
	Sex_name VARCHAR(50) NOT NULL
);
GO

-- Tạo bảng teachers
CREATE TABLE Teachers (
    teacher_id INT PRIMARY KEY ,
    user_id INT,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
GO
-- Tạo bảng students
CREATE TABLE Student (
    student_id INT PRIMARY KEY ,
    user_id INT,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
GO
CREATE TABLE Learn_class (
    learn_class_id INT PRIMARY KEY ,
    student_id INT,
    class_id INT,
    FOREIGN KEY (student_id) REFERENCES Student(student_id),
    FOREIGN KEY (class_id) REFERENCES Class(class_id)
);
GO
-- Tạo bảng staff
CREATE TABLE Staff (
    staff_id INT PRIMARY KEY ,
    user_id INT,
    full_name VARCHAR(100) NOT NULL,
    email VARCHAR(100),
    FOREIGN KEY (user_id) REFERENCES users(user_id)
);
GO
-- Tạo bảng activities
CREATE TABLE Activities (
    activity_id INT PRIMARY KEY ,
	staff_id int,
    activity_name VARCHAR(100) NOT NULL,
	activity_date date,
    description TEXT,
	FOREIGN KEY (staff_id) REFERENCES Staff(staff_id)
);
GO
-- Tạo bảng subjects
CREATE TABLE Subjects (
    subject_id INT PRIMARY KEY ,
    subject_name VARCHAR(100) NOT NULL
);
GO
-- Tạo bảng teacher_subject
CREATE TABLE Teacher_subject (
    teacher_subject_id INT PRIMARY KEY ,
    teacher_id INT,
    subject_id INT,
    FOREIGN KEY (teacher_id) REFERENCES teachers(teacher_id),
    FOREIGN KEY (subject_id) REFERENCES subjects(subject_id)
);
GO
-- Tạo bảng classes
CREATE TABLE Class (
    class_id INT PRIMARY KEY ,
    class_name VARCHAR(100) NOT NULL,
    semester_id INT,
    FOREIGN KEY (semester_id) REFERENCES Semester(semester_id)
);
GO
-- Tạo bảng semesters
CREATE TABLE Semester (
    semester_id INT PRIMARY KEY,
    semester_name VARCHAR(50) NOT NULL,
    schedule VARCHAR(50),
	start_date DATE,
    end_date DATE
     
);
GO
-- Tạo bảng schedules

