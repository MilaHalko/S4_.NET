# **Computer Workshop #2:** *LINQ to XML*
**Objective:** *To become familiar with processing XML documents using the technology
LINQ to XML.*

## :brain: Statement of the task of computer workshop #2:
The following steps are required for the computer workshop:
1) Develop an XML structure for storing data according to the options, listed below.
2) Create an XML file using XmlWriter. The data should be entered from the console and save it. Load the file using XmlDocument.
3) LINQ to XML:
    a. Output the content of the file created in step 2.
    b. Develop at least 15 different queries for the file created in step 2, using different actions on the received data. The queries must not must not be repeated.
4) Create software that implements data processing from using the LINQ to XML library.
5) The software needs to be developed as a console C# language application.

All variants you can find [here](https://github.com/MilaHalko/C4_.NET/blob/Lab2/AllVariants2.pdf) :point_left:.

## :eyes: Variant #1:
Develop a data structure to store information about diploma students and their supervisors. 
At least the following information should be stored about the students: Full name, group, date of birth, grade point average. 
About the supervisors: Name, title. One supervisor may have several graduate students.

## :floppy_disk: About the XML file:
The corresponding classes resulted in the following XML file structure with the elements: students, supervisors, Subjects. According to this, 3 of them have all attributes from their initial classes as descendants. Where the attributes contained objects of other classes, only the id of the object was taken.

## :books: About the software:
The structure of the software is as follows:
1) Creating objects and filling them with data;
2) Creation of XML file structure (described in "About XML file");
3) Interaction with the XML file to output the content;
4) LINQ queries through an XML file (section "LINQ to XML").

## :black_nib: LINQ to XML:
The final and most part are LINQ queries to XML. During development, 15 queries were created using different set actions: order by, where, group by, take, skip while, join, union, etc. (Fig. 2).

:memo: [Full report PDF](https://github.com/MilaHalko/C4_.NET/blob/Lab2/Lab2.pdf)/[docx](https://github.com/MilaHalko/C4_.NET/blob/Lab2/Lab2.docx)

:computer: [Full code](https://github.com/MilaHalko/C4_.NET/tree/Lab2/Lab2_XML/Lab2_XML) 
