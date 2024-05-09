create table teacher(
TeacherId INT PRIMARY KEY,
Name NVARCHAR(100),
Age INT,
Sex NCHAR(10),
Email NVARCHAR(100),
Discipline NVARCHAR(100)
);

create table student(
StudentId INT PRIMARY KEY,
Name NVARCHAR(100),
Age INT,
Sex NCHAR(10),
Email NVARCHAR(100),
Grade NVARCHAR(2)
);

CREATE TABLE student_teacher (
    StudentId INT,
    TeacherId INT,
    PRIMARY KEY (StudentId, TeacherId),
    FOREIGN KEY (StudentId) REFERENCES Student(StudentId),
    FOREIGN KEY (TeacherId) REFERENCES Teacher(TeacherId)
);
