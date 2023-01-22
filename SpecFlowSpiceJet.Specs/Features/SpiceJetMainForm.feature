Feature: Spice Jet Main Form

@SpiceJet
@Test
@FrontEnd

Scenario: Leave destination field empty and book flight
	When I click Search flight CTA
	Then I see Destination can not be empty pop up message appear


@SpiceJet
@Test
@FrontEnd

Scenario: Compare page title 
	When I compare page title with expected value
	Then actual title = expected title


@SpiceJet
@Test
@FrontEnd

Scenario: Check Manage Booking tab 
	When I click Manage booking link
	Then I check View change assist button is no null


@SpiceJet
@Test
@FrontEnd

Scenario: Search default values and Dismiss button is present 
	When I click Search button
	Then I check that DISMISS button is present


@SpiceJet
@Test
@FrontEnd

Scenario: Covid link is clickable 
	When I click COVID link
	Then Link opens


@SpiceJet
@Test
@FrontEnd

Scenario: 'CheckIn' TabFields Check
	When I click Check-in tab
	And I print random email address in email field
	And Clear printed text
	Then Text field email is cleared
	

@SpiceJet
@Test
@FrontEnd

Scenario: Check that registration page opens in new window
	When I click sign-up link
	Then Sign-up link opens in a new tab
	

@SpiceJet
@Test
@FrontEnd

Scenario: Try to login using random phone
	When I click login button
	When I Print randomly generated phone number to phone field and click login
	Then Validation message about non existing phone number appear


@SpiceJet
@Test
@FrontEnd

Scenario: OCR text recognition 
	When I make page screenshot and save it locally as png
	And Get text from this screenshot
	Then I compare text with expected text
