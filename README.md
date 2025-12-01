# Inventory Management Web Application Design Document

## I. Introduction
Inventory Management is a web-based tool that allows users to track their household inventory across various categories and locations. Users can add products (e.g., “Chobani Greek Yogurt”), specify their location (e.g., “Pantry”), and manage data like quantity and expiry dates.

A key feature of this application is the integration of external data sources to provide users with valuable insights. Once a product is added (especially food items), the app will fetch and display:
- **Health Score:** A rating based on the product's ingredients.
- **Green Score:** A rating indicating the product's environmental friendliness.


## II. Icon/Logo
![SafeStreet (1) (1)](https://github.com/dhumalpn/7024-Inventory-Management-Web-App/blob/main/InventoryManagement/InventoryManagement/wwwroot/img/Logo.png)

## III. Storyboard
The following describes the intended user flow and screen layout.

### Frame 1: Default Page (Landing State)
**Purpose:** This is the main page app screen where users start by looking up an item using UPC and can also see their existing inventory immediately.

**Widgets:**
- **Top Navigation Bar:** Logo | House Buddy | Home | Inventory | Shopping List (Future)
- **UPC lookup area:** UPC input field, “Lookup” button, helper text/example UPC
- **Lookup results panel area:** Empty in this state (appears after a lookup)
- **Inventory section:**
  - Section header: “My Inventory” with item count badge (example: “5 items”)
  - Inventory grid of item cards, each card shows:
    - Product image
    - Product name
    - UPC
    - Category tag
    - Quantity
    - Expiry date
    - Storage location
    - Action buttons: Edit, Delete, Health Score, Green Score (Calls API when clicked)
  - **"View by Place" List:** A list of configured locations (e.g., "Pantry," "Restroom," "Office") with an item count for each.
  - **"Alerts" Section (Future Enhancement):**
    - “Expiring Soon” (e.g., “Eggs - 2 days left”)
    - “Low Stock” (e.g., “Milk - 0 remaining”)

### Frame 2: UPC Lookup Success (Product Found State)
**Purpose:** After the user searches by UPC, the page displays the matched product details and allows the user to add it to inventory on the same screen.

**Trigger:** User enters a UPC into the “Search by UPC” input field and clicks the “Lookup” button.

**On-screen behavior:**
- Hero card remains at the top with the title “Manage Items”
- UPC input field remains populated with the entered UPC
- Product details panel appears under the Lookup button showing:
  - Product image thumbnail
  - Product name (example: “Captain Morgan Original Spiced Rum, 750 mL”)
  - Brand
  - Model (if available)
  - Category path (from the lookup source)
  - UPC number
- Add-to-inventory form appears in the same panel with:
  - Quantity input field
  - Expiry date picker
  - Storage dropdown (location selection)
  - Primary action button: “Add to Inventory”

**Expected result:**
- When the user fills Quantity, Expiry Date, Storage, and clicks “Add to Inventory”, a new item card is added to the “My Inventory” grid below without leaving the page.

### Frame 3: UPC Lookup Not Found (No Product Found State)
**Purpose:** Inform the user that the UPC lookup did not return a match while keeping them on the same page.

**Trigger:** User enters a UPC in the “Search by UPC” field and clicks “Lookup”, but the data source returns no results.

**On-screen behavior:**
- Hero card remains with the title “Manage Items”
- UPC input field remains populated with the entered UPC
- A warning/notification message appears inside the hero card:
  - “No product found for this UPC.”
- The “My Inventory” section remains visible below with the existing inventory cards unchanged

**Expected result:**
- No product details panel is shown
- No “Add to Inventory” form is shown because no product data is available

### Frame 4: Add to Inventory Success (Item Added State)
**Purpose:** Confirm that the product was successfully added and show the updated inventory immediately on the same page.

**Trigger:** User performs a successful UPC lookup, fills in Quantity, Expiry Date, Storage, and clicks “Add to Inventory”.

**On-screen behavior:**
- Hero card returns to the default lookup view (UPC field placeholder is visible)
- A success message appears on the page:
  - “Product added to your inventory.”
- The “My Inventory” section updates immediately:
  - Item count badge increases (example: from “3 items” to “4 items”)
  - A new inventory card appears in the grid for the newly added product (example: Nutella)
  - The new card shows:
    - Product image
    - Product name
    - UPC
    - Category tag
    - Quantity
    - Expiry date
    - Storage location
    - Action buttons: Edit, Delete, Health Score, Green Score (Calls API when clicked)

## IV. Projects (GitHub)
Work is planned and tracked using **GitHub Issues** and **GitHub Projects** within our repository. We create an Issue for each feature, bug, or task (with clear acceptance criteria), and then add those issues to a GitHub Project board to manage progress across stages such as **Backlog**, **To Do**, **In Progress**, **Review**, and **Done**.

Link: https://github.com/dhumalpn/7024-Inventory-Management-Web-App

## V. User Requirements

### Requirement 1: Add a product using UPC lookup
As a user, I want to add a new product to my inventory so that I can track its quantity, location, and expiry.

#### Example 1.1 (UPC lookup success shows product facts on screen)
- Given I am on the “Manage Items” landing page and the UPC input field is visible  
- And I enter UPC “818290011534” and click “Lookup”  
- And the app receives these product facts from the data source:
  - Product Name: “Chobani Greek Yogurt Variety Pack, 16 Count”
  - Brand: “Chobani”
  - Category: “Snack Foods”
  - UPC: “818290011534”
- When the lookup completes  
- Then the page should display a product details panel showing:
  - Product image thumbnail
  - Product Name exactly as “Chobani Greek Yogurt Variety Pack, 16 Count”
  - Brand exactly as “Chobani”
  - Category exactly as “Snack Foods”
  - UPC exactly as “818290011534”
- And the add-to-inventory form fields should be visible under the product details:
  - Quantity input
  - Expiry Date picker
  - Storage dropdown
  - “Add to Inventory” button

#### Example 1.2 (Add looked-up product with user-entered inventory fields)
- Given the product details panel is showing:
  - Product Name: “Chobani Greek Yogurt Variety Pack, 16 Count”
  - UPC: “818290011534”
- When I set Quantity to “4”, select Storage as “Fridge”, set Expiry Date to “12/20/2025”, and click “Add to Inventory”
- Then a success message should appear: “Product added to your inventory.”
- And the “My Inventory” item count should increase by 1
- And a new inventory card should appear showing:
  - Product Name: “Chobani Greek Yogurt Variety Pack, 16 Count”
  - UPC: “818290011534”
  - Quantity: “4”
  - Expiry: “2025-12-20”
  - Storage: “Fridge”

#### Example 1.3 (UPC lookup not found shows clear message)
- Given I am on the “Manage Items” landing page  
- And I enter UPC “3017620422003” and click “Lookup”  
- And the data source returns no matching product  
- When the lookup completes  
- Then the page should display the message: “No product found for this UPC.”
- And no product details panel should be displayed
- And the inventory grid should remain unchanged

### Requirement 2: Display Health Score and Green Score for supported products
As a user, I want to see the Health Score and Green Score directly on the inventory cards so that I can make informed decisions about food items I store.

#### Example 2.1 (Scores are shown for a food product when available)
- Given I have an inventory item with:
  - Product Name: “Chobani Greek Yogurt Variety Pack, 16 Count”
  - UPC: “818290011534”
- And Open Food Facts returns these scores for the UPC:
  - Health Score (Nutri-Score): “B”
  - Green Score (Eco-Score): “C”
- When the “My Inventory” grid is displayed  
- Then the Chobani inventory card should show (when clicked on the score action button):
  - Health Score badge: “Health: B”
  - Green Score badge: “Green: C”

### Requirement 3: Edit an inventory item from the same page
As a user, I want to edit an existing inventory item so that I can keep my quantity, expiry date, and storage location accurate.

#### Example 3.1 (Update quantity)
- Given I can see an inventory card for “Milk” showing Quantity “1”
- When I click “Edit”, change Quantity to “0” (because I finished it), and save changes
- Then the Milk card should update to show Quantity “0” in the grid

#### Example 3.2 (Update expiry date)
- Given I can see an inventory card for “Eggs” showing Expiry “2025-11-10”
- When I click “Edit”, change the expiry date to “2025-11-17”, and save changes
- Then the Eggs card should update to show Expiry “2025-11-17” in the grid

### Requirement 4: Confirm successful add to inventory on the same screen
As a user, I want immediate confirmation after adding an item so that I know the action succeeded without navigating away.

#### Example 4.1 (Success state updates inventory list and count)
- Given I have successfully looked up a product and filled Quantity, Storage, and Expiry Date
- When I click “Add to Inventory”
- Then I should see the message “Product added to your inventory.”
- And the inventory count badge should increase (example: “3 items” to “4 items”)
- And the newly added product should appear as a new card in the inventory grid with the selected Quantity, Expiry Date, and Storage

## VI. Data Sources

### External Data Sources (APIs)

#### 1. Open Food Facts API
- URL: https://world.openfoodfacts.org  
- Usage: This will be the primary source for product data. We will use it to fetch:
  - Product Name & Image
  - Ingredients list (to determine Health Score)
  - Eco-Score (to be used as our “Green Score”)
  - Nutri-Score (to be used as our “Health Score”)
  - Product categorization (which we can map to our internal categories)

#### 2. UPC Item DB API (or similar)
- URL: https://www.upcitemdb.com/api/  
- Usage: A secondary lookup service. If a product isn't found in Open Food Facts, or for non-food items, this API can be used to look up a product name from a scanned barcode (UPC).

### Internally Developed Data Sources

#### 1. Place Categorization (XML/JSON)
- Format: A simple XML file stored within the application (e.g., `places.xml`). This file will be read by the app to populate the “Place” dropdown.
- Example Data: Pantry, Restroom, Bedroom, Office, Frozen.

#### 2. Product Categorization (XML/JSON)
- Format: A simple XML file (e.g., `categories.xml`) that defines the parent categories we want to use.
- Usage: This will populate the “Category” dropdown. We will attempt to map the detailed categories from Open Food Facts (e.g., “yogurts”) to our simpler internal categories (e.g., “Dairy”).
- Example Data: Fruits, Vegetables, Grains, Dairy, Bakery, Frozen, Household.

### User-Inputted Data (Stored in Database)
- User Inventory: The core database table linking a UserID to a ProductID
- Quantity: The current count of the item, entered by the user
- Expiry Date: (Optional) The specific expiry date for the item, set by the user
- Custom Image: (Optional) A photo uploaded by the user if an API image is not available or incorrect

## VII. Team Composition

### Team Members
(Responsibilities of each member to be determined in the next meeting)
- Harshitha Baratam
- Narayan Shanku
- Pooja Dhumal
- Rohan Barai

### Weekly Team Meeting
Every Thursday, 8:00 PM - 09:00 PM at Lindner College of Business



<!--
# Inventory Management Web Application Design Document

## I. Introduction

This document outlines the design for the Inventory Management Web App. The application is a web-based tool that allows users to track their household inventory across various categories and locations. Users can add products (e.g., "Chobani Greek Yogurt"), specify their location (e.g., "Pantry"), and manage data like quantity and expiry dates.

A key feature of this application is the integration of external data sources to provide users with valuable insights. Once a product is added (especially food items), the app will fetch and display:

* Health Score: A rating based on the product's ingredients.
* Green Score: A rating indicating the product's environmental friendliness.


## II. Icon/Logo
![SafeStreet (1) (1)](https://github.com/dhumalpn/7024-Inventory-Management-Web-App/blob/main/InventoryManagement/InventoryManagement/wwwroot/img/Logo.png)



## III. Storyboard

The following describes the intended user flow and screen layout-

### Screen 1: Dashboard (Home Screen)

* **Purpose:** Provide a high-level overview and quick navigation.
* **Widgets:**
    * Header: App Logo and Title ("My Inventory").
    * "Quick Add" Button: A prominent "+" button to quickly add a new item.
    * "Alerts" Section (Future Enhancement):
        * "Expiring Soon" (e.g., "Eggs - 2 days left").
        * "Low Stock" (e.g., "Milk - 0 remaining").
    * "View by Place" List: A list of configured locations (e.g., "Pantry," "Restroom," "Office") with an item count for each.
    * Navigation Bar (Bottom): Home | Inventory | Shopping List (Future) | Settings.

### Screen 2: Inventory List (Filtered by Place)

* **Purpose:** Display all items within a selected location.
* **Trigger:** User taps on "Pantry" from the Dashboard.
* **Widgets:**
    * Header: "Pantry".
    * Search Bar: To filter items within the pantry.
    * Item List: A scrollable list of products. Each list item shows:
        * Product Image (small thumbnail).
        * Product Name ("Chobani Greek Yogurt").
        * Quantity ("Qty: 2").
        * Expiry Date ("Exp: 11/15/2025").

### Screen 3: Add/Edit Item Screen

* **Purpose:** Add a new item or edit an existing one.
* **Trigger:** User taps the "Quick Add" button or taps an existing item from the list.
* **Widgets:**
    * "Scan Barcode" Button: (Future enhancement).
    * “Add item” Button: (Manual Input method)
    * Product Image: (Populated from API or user upload).
    * Product Name: (e.g., "Chobani Greek Yogurt, Vanilla").
    * Quantity: (Input field, e.g., "2").
    * Expiry Date: (Date picker).
    * Place (Dropdown): "Pantry," "Restroom," etc.
    * Category (Dropdown): "Dairy," "Grains," etc. (Often populated automatically from API data).
    * Scores Section (Read-only):
        * Health Score: "Good" (75/100).
        * Green Score: "B" (Eco-Score).
    * "Save" Button.
    * "Delete" Button (Only visible when editing).


## IV. Projects (GitHub)

Work will be planned and tracked using GitHub Projects within the project repository.

Link - https://github.com/dhumalpn/7024-Inventory-Management-Web-App


## V. User Requirements

### Requirement 1: Adding a Product

As a user, I want to add a new product to my inventory so that I can track its quantity, location, and expiry.
* **Example 1.1 (Adding via API lookup):**
    * Given I am on the "Add Item" screen.
    * When I search for "Chobani Greek Yogurt Vanilla" and select the correct item from the results.
    * Then the app should query Open Food Facts, auto-fill the Product Name, Category ("Dairy"), Health Score, and Green Score.
* **Example 1.2 (Setting custom data):**
    * Given I have just looked up "Chobani Greek Yogurt."
    * When I set the Quantity to "4", select "Pantry" as the Place, and set the Expiry Date to "11/20/2025".
    * Then the item is saved to my "Pantry" inventory with all the specified details.
* **Example 1.3 (Adding a non-food item):**
    * Given I am on the "Add Item" screen.
    * When I manually type "Paper Towels", set Category to "Office" (or "Household"), set Place to "Restroom", and Quantity to "1".
    * Then the item is saved to my "Restroom" inventory (Health and Green Scores may be "N/A").

### Requirement 2: Viewing Product Scores

As a user, I want to see the Health Score and Green Score for my products so that I can make informed decisions about my items.
* **Example 2.1 (Viewing scores on details page):**
    * Given I have "Chobani Greek Yogurt" in my inventory.
    * When I tap on that item from the "Inventory List" to open the "Edit Item" screen.
    * Then I should see a "Health Score" (e.g., "Good") and a "Green Score" (e.g., "Eco-Score: B") displayed clearly on the screen.

### Requirement 3: Managing Inventory

As a user, I want to update the quantity and expiry date of an item so that my inventory remains accurate.
* **Example 3.1 (Updating quantity):**
    * Given I am viewing the "Item Details" for "Milk," which has a current quantity of "1".
    * When I change the quantity input field to "0" (because I finished it) and press "Save".
    * Then the inventory list should reflect that "Milk" has a quantity of "0".
* **Example 3.2 (Updating expiry date):**
    * Given I am viewing the "Item Details" for "Eggs" with an expiry date of "11/10/2025".
    * When I use the date picker to change the expiry date to "11/17/2025" and press "Save".
    * Then the item "Eggs" is saved with the new expiry date.

### Requirement 4: Organizing Inventory

As a user, I want to filter my inventory list by place so that I can easily see what I have in a specific location (e.g., "Pantry").
* **Example 4.1 (Filtering by place):**
    * Given I have "Cereal" saved to "Pantry" and "Shampoo" saved to "Restroom".
    * When I navigate to the Dashboard and tap on the "Pantry" location.
    * Then I should see "Cereal" in the resulting "Inventory List", but I should not see "Shampoo".


## VI. Data Sources

**External Data Sources (APIs):**

1.  **Open Food Facts API:**
    * URL: https://world.openfoodfacts.org
    * Usage: This will be the primary source for product data. We will use it to fetch:
        * Product Name & Image.
        * Ingredients list (to determine Health Score).
        * Eco-Score (to be used as our "Green Score").
        * Nutri-Score (to be used as our "Health Score").
        * Product categorization (which we can map to our internal categories).
2.  **UPC Item DB API (or similar):**
    * URL: https://www.upcitemdb.com/api/
    * Usage: A secondary lookup service. If a product isn't found in Open Food Facts, or for non-food items, this API can be used to look up a product name from a scanned barcode (UPC).

**Internally Developed Data Sources:**

1.  **Place Categorization (XML/JSON):**
    * Format: A simple XML file stored within the application (e.g., places.xml). This file will be read by the app to populate the "Place" dropdown.
    * Example Data: Pantry, Restroom, Bedroom, Office, Frozen.
2.  **Product Categorization (XML/JSON):**
    * Format: A simple XML file (e.g., categories.xml) that defines the parent categories we want to use.
    * Usage: This will populate the "Category" dropdown. We will attempt to map the detailed categories from Open Food Facts (e.g., "yogurts") to our simpler internal categories (e.g., "Dairy").
    * Example Data: Fruits, Vegetables, Grains, Dairy, Bakery, Frozen, Household.

**User-Inputted Data (Stored in Database):**

* User Inventory: The core database table linking a UserID to a ProductID.
* Quantity: The current count of the item, entered by the user.
* Expiry Date: (Optional) The specific expiry date for the item, set by the user.
* Custom Image: (Optional) A photo uploaded by the user if an API image is not available or incorrect.


## VII. Team Composition

   ### Team Members
   (Responsibilities of each member to be determined in the next meeting)
   * Harshitha Baratam
   * Narayan Shanku
   * Pooja Dhumal
   * Rohan Barai

   ### Weekly Team Meeting

   Every Thursday, 8:00 PM - 09:00 PM at Lindner College of Business-->
