# Computer Workshop #1: *LINQ to Objects*:
**Objective:** *To become familiar with data processing using the LINQ to Objects library.*

## :brain: Statement of the Task for Computer Workshop #1:
In performing the computer workshop, the following steps must be performed:
1) Develop a data structure to store according to the options below. There should be at least 3-4 classes in each of the options. The implementation should demonstrate relationships between classes: one-to-many and many-to-many.
2) Develop at least 15 different queries using different actions on sets: grouping, sorting, filtering, combining results of several queries into one (join, concat) and other. In addition, it is necessary to use two possible ways of implementing LINQ queries (classical and extension methods), and the queries should not be repeated.
3) Create software that implements data processing using the LINQ to Objects library.
4) The software needs to be developed through console application in C# language.

All variants you can find [here](https://github.com/MilaHalko/C4_.NET/blob/Lab1/AllVariants.pdf) :point_left:.

## :eyes: Variant #1:
Develop a data structure to store information about diploma students and their supervisors. 
At least the following information should be stored about the students: Full name, group, date of birth, grade point average. 
About the supervisors: Name, title. One supervisor may have several graduate students.

## :muscle: Class Description: 
During the development of the software, 3 classes were created: Student, Supervisor, Subject.
- The Student class implements a student who has one supervisor and many subjects. In general, it has attributes: ID, full name, group, date of birth, supervisor, subjects with grades and a method to calculate the grade point average.
- The Supervisor class implements a supervisor, which can have multiple grading students. The supervisor has attributes: ID, full name, position.
- The Subject class implements a discipline. Each discipline has a list of students who study the same subject name as attributes.

As a result of creating the above-mentioned classes, mappings like: one to many (supervisor to student); many to many (student to subject) were reproduced. :whale:
[Full report](https://github.com/MilaHalko/C4_.NET/blob/Lab1/Lab1.docx) :memo:
[Full code](https://github.com/MilaHalko/C4_.NET/tree/Lab1/Lab1_LINQ/Lab1_LINQ) :computer:
