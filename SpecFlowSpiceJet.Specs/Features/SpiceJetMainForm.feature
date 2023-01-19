Feature: Spice Jet Main Form

@SpiceJet
@Test
@FrontEnd

Scenario: Leave destination field empty and book flight
	When I click 'Search flight' CTA
	Then I see 'Destination can not be empty' pop up message appear


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
	When I click 'Manage booking link'
	Then I check 'View change assist' button is no null
