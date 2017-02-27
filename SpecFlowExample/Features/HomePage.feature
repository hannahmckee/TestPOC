@Home
Feature: HomePage
	As a visitor
	I want to be able to navigate the Waterways Ireland Home Page

@UI
Scenario: Logo should be visible
	Given I have navigated to the Waterways Ireland Home Page
	Then the logo should be displayed

Scenario: Map Destinations Should Match Selected Waterway
	Given I have navigated to the Waterways Ireland Home Page
	When I select the waterway named "Shannon Erne"
	Then the map destination for the waterway named "Shannon Erne" should have the css class "active"
