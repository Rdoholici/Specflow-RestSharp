Feature: Selenium Practice
    Go to the selenium practice form https://demoqa.com/text-box
    Input text in elements
    Click the submit button
    Verify the text is displayed
 
@ToDoApp
Scenario: Navigate to the practice app and interact with the form elements
    Given that I navigate to the URL: https://demoqa.com/text-box
    Then the page tile is: ToolsQA
    
    When I input the text: FirstName LastName in the element with the label: Full name
    And I input the text: email@mail.com in the element with the label: Email
    And I press the element with the text: Submit
    
    Then the text: FirstName LastName is displayed
    And the text: email@mail.com is displayed

    And I quit the driver
