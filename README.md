# **Computer Workshop #4:** Structural patterns**
**Objective:** *get acquainted with basic structural patterns, learn how to apply them in software design and development.*

## :brain: Statement of the task of computer workshop #4:
The following steps are required in completing the computer-based practice:
1) Study structural patterns. Know the general characteristics and purpose of each of them, peculiarities of implementation of each structural pattern and cases of their application.
2) Implement the task according to Variant #1. Develop interfaces and classes to apply one or more patterns. Completely implement methods related to the implementation of the selected pattern.
3) Complete outline of the project's architecture (assigning of methods and classes), peculiarities of implementation of the selected pattern. For each pattern, specify the main classes and their purpose,
4) Give a UML diagram of classes

All variants you can find [here](https://github.com/MilaHalko/C4_.NET/blob/Lab4/Reports%26Variants/AllVariants4.pdf) :point_left:.

## :eyes: Variant #1:
Develop a structure for the organization of an army in a fantasy game. The army can consist of units of elves, orcs, minotaurs, centaurs, cyclops, dragons, hydras, knights. An army can contain both troops and single warriors, a troop can consist of other troops and single warriors.

## :shrug: Choosing a pattern
According to the task, we understand that there are specific objects like Orcs, Elves, etc. They themselves can form troops, and the troops can form an army. All this resembles the structure of a tree, where specific representatives of warriors are the leaves. So, we can apply the Composite pattern. In this way, the Client will be able to work with individual parts of the tree, as well as with the whole tree. In our case, the troop is a container. The army is the same container, the root of the tree.

## :office: The architecture of the project
So, in the general abstract class Unit, let's define the attribute "name" and abstract methods for adding/removing objects. In addition, let's define abstract methods for determining the army's strength, size, number of warriors and food requirements.

From the Unit we will inherit the Troop class - the container. An obligatory attribute will be a list of Units to be able to add both new containers and warriors. As for the methods - all of them are implemented according to the task.

Also from the Unit we inherit the abstract Warrior class. This class implements several abstract methods, where the logic for all future inheritors will be the same. For example, the add and remove methods according to the pattern should not be implemented in leaves (error message). So you don't have to write the same thing many times for each warrior. It is easier to mark it 1 time in the base class.

The last step is to add Warrior descendants, specific warriors. In them we define all other unrealized methods.

:art: [Final diagramme JPG](https://github.com/MilaHalko/C4_.NET/blob/Lab4/Diagrams/Army_Class-Diagram.jpg)

:memo: [Full report PDF](https://github.com/MilaHalko/C4_.NET/blob/Lab4/Reports%26Variants/Lab4.pdf)/[docx](https://github.com/MilaHalko/C4_.NET/blob/Lab4/Reports%26Variants/Lab4.docx)

:computer: [Full code](https://github.com/MilaHalko/C4_.NET/tree/Lab4/Army/Army) 
