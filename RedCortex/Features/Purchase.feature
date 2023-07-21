Feature: Purchase

Description: Place order

@test
Scenario: Search item
	Given User is on homepage
	When I seach for 'echo dot'	
	Then I should see '3rd' and '4th' generation Echo Dot speaker

@test
Scenario: Add item to cart successfully
	Given User is on homepage
	When I seach for 'echo dot'	
	And I select '3rd' Generation echo dot
	And I add to cart
	Then I should see the item added into the basket