Feature: TitleCheck

Check that title of the site spicejet.com contains expected title


Scenario: Check Page Title value is equal to expected
	Given I have expected title for the site spicejet.com saved
	When i save site spicejet.com title to actual result variable
	Then actual text title is equal to expected title
