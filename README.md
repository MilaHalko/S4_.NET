# **Computer Workshop #3:** *Design patterns. Generating patterns*
**Objective:** *get acquainted with basic design patterns and learn how to apply them in software design and development.*

## :brain: Statement of the task of computer workshop #3:
The following steps are required in completing the Computer Practice:
1) Learn the generative patterns. Know the general characteristics and purpose of each of them, peculiarities of realization of each generating pattern and cases of their application.
2) Implement the task according to variant 1. Develop interfaces and classes for using one or more patterns. Completely implement methods related to the implementation of the selected pattern.
3) Complete outline of the project's architecture (assigning of methods and classes), peculiarities of implementation of the selected pattern. For each pattern, specify the main classes and their purpose,
4) Give a UML diagram of classes

All variants you can find [here](https://github.com/MilaHalko/C4_.NET/blob/Lab3/Reports%26Variants/AllVariants3.pdf) :point_left:.

## :eyes: Variant #1:
Еhe task "Electronic document flow". Several types of documents are being developed (e.g., letter, memo, order, order, resource request, etc.). Each document has id, date and information about the document. In addition, letters can be both input and output and has the correspondent from whom the letter was received or sent. Orders contain the subdivision, deadline and responsible executor. Orders contain only the subdivision and deadline. Resource requests contain the assistant who needs to provide access to resources, a list of resources.

## :derelict_house: Description of the problem and architecture of the project:
Since we face the problem that the final product is unknown in advance; and by the wording of the problem, there may be other document variants that can be added to the system later. It is clear that the code should be more versatile to further add new classes.

Consequently, the **factory method** will be the best way to implement it. This pattern allows us to make the code universal because there is no binding to specific classes. To implement it, we need a generic abstract class, *DocCreator*. All other Cretors will inherit from it to create each of the files (*Doc* heirs).

The only problem is that the files have different attributes. In this paper, the abstract class *DocArgs* and its descendants (the role of a repository) were created to pass all the necessary values to create files. The object of the *DocArgs* class will be passed to the constructor of the *DocCreator* heir for further extraction of values. Depending on the passed *DocArgs* heir, a specific *DocCreator* heir will be created..

:art: [Final diagramme JPG](https://github.com/MilaHalko/C4_.NET/blob/Lab3/Diagrams/Docs.png)

:memo: [Full report PDF](https://github.com/MilaHalko/C4_.NET/blob/Lab3/Reports%26Variants/Lab3.pdf)/[docx](https://github.com/MilaHalko/C4_.NET/blob/Lab3/Reports%26Variants/Lab3.docx)

:computer: [Full code](https://github.com/MilaHalko/C4_.NET/tree/Lab3/Lab3/Lab3) 
