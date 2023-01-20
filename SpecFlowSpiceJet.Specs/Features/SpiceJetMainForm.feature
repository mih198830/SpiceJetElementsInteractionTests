﻿Feature: Spice Jet Main Form

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


@SpiceJet
@Test
@FrontEnd

Scenario: Search default values and Dismiss button is present 
	When I click 'Search' button
	Then I check that 'DISMISS' button is present


@SpiceJet
@Test
@FrontEnd

Scenario: Covid link is clickable 
	When I click 'COVID' link
	Then Link opens