# .Net WebAPI or ASP.NET Core Coding Test
Create a web API application that adds up 2 big numbers.
Time to complete: 60 minutes.
There should be one method that accepts 2 values and returns the sum of them. The client can input numbers which are very long and will potentially not fit into any integer data type. Therefore, the method that calculates the sum of those 2 values should accept strings as parameters and return a string as a result.
Sample of method signature:
string AddNumbers(string number1, string number 2)
## Note that
- int.Parse(value) will potentially fail as the value can be too long to fit into an integer.
- The user input should be checked for non-numerical characters in the strings and appropriate error messages should be displayed on the UI.
- Only integer numbers are allowed, without decimals (i.e. 999.58 is not allowed).
- A negative number is an integer number.
All calculations should be logged in a text file (on local drive) in the format:
timestamp, param1, param2, result
timestamp, param1, param2, result
Another API method should enable the client to check the log of operations.
Technologies to use
C#, WebAPI/ASP.NET Core.
What we value
- A functional site.
- A clean, well-organized solution structure.
- Clarity of code.
- Good coding practices.
- Unit tests.
- Self-documented code, and/or valuable comments.
### Defensive programming.
- Proper REST.
- Show off if you can
- Style the site.
- Add paging to the logs view.
- Add pages that use the WebAPI in an async way.
