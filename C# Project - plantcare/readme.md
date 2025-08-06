\# Plant Care Program



A simple console application written in C# that simulates the hydration level of a plant. The plant's hydration level decreases over time, and the user can check the status or water the plant to increase hydration. The program issues warnings when hydration levels get low and ends when the plant dies.



\## Features



\- Hydration level starts at 100% and decreases by 1% every 5 seconds.

\- Warning messages display at 50% (low hydration) and 15% (critical hydration).

\- User can type commands to:

&nbsp; - \*\*status\*\*: Display the current hydration level along with a plant visual.

&nbsp; - \*\*water\*\*: Increase hydration by 15% if the plant is not well-hydrated.

&nbsp; - \*\*exit\*\*: Exit the program.

\- Prevents watering if the plant is dead or already well-hydrated.

\- Program exits automatically when hydration reaches 0%.



\## Requirements



\- .NET runtime (the program targets .NET Core / .NET 5+)



\## Usage



1\. Compile the program using your preferred C# compiler or IDE.

2\. Run the program from the console.

3\. Use the following commands when prompted:

&nbsp;   - `status` — Check the hydration level.

&nbsp;   - `water` — Water the plant to increase hydration.

&nbsp;   - `exit` — Quit the program.



\## Constants and Configuration



The program uses named constants to configure:



\- Initial hydration level: 100%

\- Hydration decrement interval: 5 seconds

\- Hydration decrement amount: 1%

\- Low hydration warning threshold: 50%

\- Critical hydration warning threshold: 15%

\- Water increment amount: 15%

\- Maximum hydration level for watering: 85%



These can be easily modified in the source code.



\## Example Output



Welcome to the Plant Care Program!

Type 'status' to check hydration, 'water' to water the plant, or 'exit' to quit.



status



text

&nbsp;   .--.

&nbsp; .'\_\\/\_'.

&nbsp; '. /\\ .'

&nbsp;   '||'

&nbsp;    || /\\

&nbsp; /\\ ||//$$

&nbsp;(/\\\\||/

||/\_



Hydration Level: 100%



water

You watered the plant! Hydration level increased by 15%.

status

Hydration Level: 100%

exit

Ending Program.

