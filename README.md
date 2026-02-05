# Search Selector

A simple ASP.NET MVC web application that provides a unified search interface allowing users to select their preferred search engine (Google, Yahoo, or Bing) and perform searches through a clean, user-friendly interface. The application also features quick links to popular websites.

## Table of Contents
- [Features](#features)
- [Technology Stack](#technology-stack)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Configuration](#configuration)
- [Project Structure](#project-structure)
- [Usage](#usage)
- [Development](#development)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Multi-Search Engine Support**: Choose between Google, Yahoo, and Bing search providers
- **Quick Links**: Fast access to popular websites (YouTube, Facebook, Spotify, ESPN)
- **Responsive Design**: Built with Bootstrap 4.5 for mobile-friendly interface
- **Form Validation**: Client and server-side validation for search inputs
- **Analytics Integration**: Impression tracking for search and quick link usage
- **Clean UI**: Modern, intuitive interface with FontAwesome icons

## Technology Stack

- **Framework**: ASP.NET MVC 5.2.7 (.NET Framework 4.7.2)
- **Frontend**: 
  - Bootstrap 4.5.0
  - jQuery 3.4.1
  - FontAwesome 4.7.0
  - Popper.js 1.16.0
- **Backend**: C# with MVC pattern
- **Build Tools**: MSBuild
- **Package Manager**: NuGet

## Prerequisites

Before running this application, ensure you have the following installed:

- Visual Studio 2019 or later (or Visual Studio Code with C# extension)
- .NET Framework 4.7.2 or higher
- IIS Express (included with Visual Studio)
- Web browser (Chrome, Firefox, Edge, Safari)

## Installation

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd Search-Selector
   ```

2. **Restore NuGet packages**
   ```bash
   nuget restore Search-Selector.sln
   ```
   Or in Visual Studio: Right-click solution → Restore NuGet Packages

3. **Build the solution**
   ```bash
   msbuild Search-Selector.sln
   ```
   Or in Visual Studio: Build → Build Solution

4. **Run the application**
   - In Visual Studio: Press F5 or Ctrl+F5
   - The application will launch in your default browser at `https://localhost:44387`

## Configuration

The application can be configured through the `Web.config` file:

```xml
<appSettings>
  <!-- Analytics tracking endpoints -->
  <add key="SearchImpression" value="http://imp.emailaccessonline.com/impression.do?event=CaseStudySearch&amp;source=JoelHymanCaseStudy&amp;traffic_source=JoelHymanStudy" />
  <add key="QuickLinkImpression" value="http://imp.emailaccessonline.com/impression.do?event=CaseStudyQuicklink&amp;source=JoelHymanCaseStudy&amp;traffic_source=JoelHymanStudy" />
</appSettings>
```

### Customization Options

- **Quick Links**: Modify the `CreateDefaultVm()` method in `HomeController.cs` to add/remove quick links
- **Search Providers**: Add new search engines by extending the switch statement in the `Index` POST action
- **Analytics**: Update the impression URLs in `Web.config` for your analytics provider

## Project Structure

```
Search-Selector/
├── Search-Selector.sln              # Visual Studio solution file
└── Search-Selector/                 # Main project directory
    ├── App_Start/                   # Application startup configuration
    │   ├── BundleConfig.cs          # CSS/JS bundling configuration
    │   ├── FilterConfig.cs          # Action filters
    │   ├── RouteConfig.cs           # URL routing configuration
    │   └── WebApiConfig.cs          # Web API configuration
    ├── Content/                     # Static assets
    │   ├── bootstrap.css/.min.css   # Bootstrap framework
    │   ├── font-awesome.css         # FontAwesome icons
    │   ├── Site.css                 # Custom styles
    │   └── img/                     # Image assets
    ├── Controllers/                 # MVC Controllers
    │   └── HomeController.cs        # Main application controller
    ├── Models/                      # Data models
    │   ├── QuickLink.cs            # Quick link model
    │   └── SearchModel.cs          # Search form model
    ├── Scripts/                     # JavaScript libraries
    │   ├── bootstrap.js/.min.js     # Bootstrap JavaScript
    │   ├── jquery-3.4.1.js         # jQuery library
    │   └── popper.js               # Popper.js for tooltips
    ├── ViewModels/                 # View models
    │   └── SearchViewModel.cs      # Combined view model
    ├── Views/                      # Razor views
    │   ├── Home/                   # Home controller views
    │   │   ├── Index.cshtml        # Main search page
    │   │   ├── Contact.cshtml      # Contact page
    │   │   ├── Privacy.cshtml      # Privacy policy
    │   │   ├── Terms.cshtml        # Terms of service
    │   │   └── Uninstall.cshtml    # Uninstall instructions
    │   └── Shared/                 # Shared layout files
    │       ├── _Layout.cshtml      # Main layout template
    │       ├── _TopNav.cshtml      # Navigation partial
    │       └── _Footer.cshtml      # Footer partial
    ├── Global.asax/.cs             # Application lifecycle events
    ├── packages.config             # NuGet package dependencies
    └── Web.config                  # Application configuration
```

## Usage

### Basic Search
1. Open the application in your browser
2. Select a search provider by clicking on Google, Yahoo, or Bing icon
3. Enter your search term in the text field
4. Click the search button or press Enter
5. You'll be redirected to the selected search engine with your query

### Quick Links
- Click on any of the quick link tiles to navigate directly to popular websites
- Current quick links include: YouTube, Facebook, Spotify, and ESPN

### Available Pages
- **Home** (`/`): Main search interface
- **Contact** (`/Home/Contact`): Contact information
- **Privacy** (`/Home/Privacy`): Privacy policy
- **Terms** (`/Home/Terms`): Terms of service
- **Uninstall** (`/Home/Uninstall`): Uninstall instructions

## Development

### Key Components

1. **SearchModel**: Handles search form data with validation
   ```csharp
   public class SearchModel
   {
       [Required(ErrorMessage = "Please select a search provider")]
       public string SearchEngineName { get; set; }
       
       [Required(ErrorMessage = "Please enter a search term")]
       public string SearchTerm { get; set; }
   }
   ```

2. **QuickLink**: Represents quick access links
   ```csharp
   public class QuickLink
   {
       public string Name { get; set; }
       public string QuickLinkUrl { get; set; }
       public string Image { get; set; }
   }
   ```

3. **SearchViewModel**: Combines search and quick link data for the view

### Adding New Search Providers

To add a new search provider:

1. Update the `Index.cshtml` view to include the new provider button
2. Modify the switch statement in `HomeController.Index` POST method
3. Add appropriate styling and icons

### Customizing Quick Links

Modify the `CreateDefaultVm()` method in `HomeController.cs`:

```csharp
QuickLinks = new List<QuickLink>
{
    new QuickLink
    {
        QuickLinkUrl = "https://example.com",
        Image = "~/Content/img/example.png",
        Name = "Example Site"
    }
}
```

### Development Environment Setup

1. Clone the repository
2. Open `Search-Selector.sln` in Visual Studio
3. Restore NuGet packages
4. Build the solution
5. Set the web project as startup project
6. Press F5 to run with debugging

## Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Code Style Guidelines

- Follow C# naming conventions
- Use meaningful variable and method names
- Add XML documentation for public methods
- Maintain consistent indentation (4 spaces)
- Write unit tests for new functionality

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Bootstrap team for the responsive framework
- FontAwesome for the icon library
- Microsoft for ASP.NET MVC framework
- jQuery team for the JavaScript library