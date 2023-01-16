Feature: Flight tab destination field check

@SpiceJet
@Test
@FrontEnd

Scenario: Leave destination field empty and book flight
	When I click 'Search flight' CTA
	Then I see 'Destination can not be empty' pop up message appear