@WhatsOn
Feature: WhatsOnPage
	In order to see all upcoming events
	As a visitor
	I want to be able to filter all Waterways Ireland events

Scenario: All Upcoming Events are Displayed by Default
	Given I have navigated to the Waterways Ireland What's On Page
	Then 2 upcoming events should be displayed

Scenario: All Expected Upcoming Events are Displayed
	Given I have navigated to the Waterways Ireland What's On Page
	Then the following events should be displayed
		| EventName           |
		| Floating Cinema     |
		| Mother's Day Cruise |

Scenario: All Relevant Events are Displayed When Filters are Applied
	Given I have navigated to the Waterways Ireland What's On Page
	When I select the location "Barrow Navigation"
	And I select the Event Type "Community/Family Fun"
	And I select the Event Start Date 2/5/2015
	And I select the Event End Date 3/5/2015
	And I filter the displayed events
	Then 1 upcoming events should be displayed
	And the following events should be displayed
		| EventName                |
		| Athy Dragon Boat Regatta |

Scenario: Message should be displayed when No Events are Available
	Given I have navigated to the Waterways Ireland What's On Page
	When I select the location "Barrow Navigation"
	And I select the Event Type "Community/Family Fun"
	And I select the Event Start Date 2/5/2020
	And I filter the displayed events
	Then 0 upcoming events should be displayed
	And No Events Found Message should be displayed