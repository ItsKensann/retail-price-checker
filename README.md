# Retail Price Checker

⚠️ Disclaimer: This repository is a portfolio showcase of work completed during an internship. The code is provided for demonstration purposes only and is not functional in its current state, as it requires internal API keys, connection strings, and other proprietary configurations that have been removed for security reasons. This project is intended to display the scope and quality of work completed during the internship period.

## Overview

The Retail Price Checker provides customers with a seamless way to verify product pricing in real-time. By scanning a Universal Product Code (UPC), users can access comprehensive product information including current price, description, images, size, and color options tailored to their specific store location.

### Key Features

- **UPC Scanning**: Quick product lookup via Universal Product Code
- **Real-Time Pricing**: Accurate, up-to-date pricing information
- **Product Details**: Comprehensive display of product attributes (name, description, size, color)
- **Product Images**: Visual confirmation of items
- **Store-Specific Data**: Pricing and availability based on selected location
- **Intuitive Interface**: Clean, centered design with clear call-to-action buttons

## User Experience

### Home Page

The landing page welcomes users with:
- **Application Name**: Clear branding and identification
- **Purpose Statement**: "Use our Price Check tool for an accurate look up of any Columbia retail product. Simply scan the product's Universal Product Code to display the price, image, and description of the item."
- **Get Started Button**: Direct navigation to the Price Check functionality
- **Centered Design**: Professional, focused layout

### Price Check Page

The core functionality page provides:

1. **UPC Input Interface**: Scan or enter product UPC
2. **Submit Button**: Initiates product lookup
3. **Dynamic Results Display**:
   - Loading state during data fetch
   - Product image
   - Current price
   - Product name/description
   - Size options
   - Color variants
4. **Scan Another Item Button**: Quick access to perform additional lookups

<img width="500" height="349" alt="image" src="https://github.com/user-attachments/assets/c4f05763-8c19-4448-a9ae-500d022824d5" />

## Architecture

### Frontend Stack

- **Framework**: Blazor WebAssembly / Blazor Server
- **Language**: C# / .NET
- **UI Components**: Razor components
- **Styling**: CSS (centered, responsive design)

### Service Integration

The application integrates with multiple backend microservices:

#### 1. Commerce Pricing Service
- **Purpose**: Retrieves real-time pricing information
- **Data**: Current prices by item and store location

#### 2. Retail Product Service
- **Purpose**: Fetches comprehensive product information
- **Data**: Product descriptions, attributes, specifications

#### 3. Image Service
- **Purpose**: Provides product imagery
- **Data**: High-quality product photos

#### 4. Location Service
- **Purpose**: Determines store-specific information
- **Data**: Store locations, regional data

### Middleware Layer

The application implements a custom middleware layer that:
- **Processes User Input**: Validates and sanitizes UPC data from the UI
- **Orchestrates Service Calls**: Coordinates requests across multiple backend services
- **Handles Data Aggregation**: Combines responses from various services into a unified result
- **Manages State**: Handles loading states and error scenarios

## Key Features Implementation

### Dependency Injection

Services are registered and injected using .NET's built-in dependency injection:

```csharp
// Example service registration
builder.Services.AddScoped<IRetailProdClientService, RetailProdClientService>();
builder.Services.AddScoped<IPricingClientService, PricingClientService>();
```

## User Flow

```
1. User lands on Home page
   ↓
2. Clicks "Get Started" button
   ↓
3. Navigates to /price-check
   ↓
4. Enters/scans UPC
   ↓
5. Clicks "Submit"
   ↓
6. Loading indicator appears
   ↓
7. Results display (image, price, details)
   ↓
8. User can click "Scan Another Item" to repeat
```

## Future Enhancements

- Login for employees
- Shift to a more flexible frontend framework like React
- Mobile responsive UI
- Physical UPC barcode scanning 
- Store location selection/detection at login
- Price comparison across multiple locations
- Product availability status
- Price history tracking
