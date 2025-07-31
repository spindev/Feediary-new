# Feediary - Baby Feed Diary

A beautiful, mobile-first web application for tracking your baby's feeding schedule. Built with .NET 8 and Blazor Server, designed to behave like a native mobile app on iOS and Android.

## Features

- **Mobile-First Design**: Optimized for mobile devices with touch-friendly navigation
- **Bottom Navigation**: Native app-like navigation with Home, Calendar, and Settings
- **Baby-Friendly Theme**: Soft colors and emoji icons designed for parents
- **Time-based Greetings**: Dynamic greetings based on time of day
- **Feeding Tracking**: Track feeding times, amounts, and patterns
- **Calendar View**: View feeding schedules and summaries
- **Settings Management**: Customize app preferences and baby profile
- **Code-Behind Approach**: Clean separation of layout and logic
- **Docker Support**: Easy self-hosted deployment

## Technology Stack

- .NET 8
- Blazor Server
- CSS3 with Mobile-First responsive design
- Docker for containerization

## Quick Start

### Option 1: Docker (Recommended)

```bash
# Clone the repository
git clone https://github.com/spindev/Feediary-new.git
cd Feediary-new

# Build and run with Docker Compose
docker-compose up -d

# The app will be available at http://localhost:8080
```

### Option 2: Local Development

```bash
# Prerequisites: .NET 8 SDK
cd Feediary
dotnet restore
dotnet run

# The app will be available at http://localhost:5000
```

## Project Structure

```
Feediary/
├── Components/
│   ├── Layout/
│   │   ├── MobileLayout.razor          # Mobile-first layout
│   │   ├── MobileLayout.razor.cs       # Layout code-behind
│   │   └── MobileLayout.razor.css      # Mobile-specific styles
│   └── Pages/
│       ├── Home.razor                  # Landing page
│       ├── Home.razor.cs               # Home page logic
│       ├── Calendar.razor              # Feeding calendar
│       ├── Calendar.razor.cs           # Calendar logic
│       ├── Settings.razor              # App settings
│       └── Settings.razor.cs           # Settings logic
├── wwwroot/
│   └── app-mobile.css                  # Global mobile styles
├── Dockerfile                          # Production container
└── docker-compose.yml                  # Easy deployment
```

## Features Overview

### 🏠 Home Page
- Welcome message with time-based greeting
- Feature overview cards
- Baby-themed design with emoji icons

### 📅 Calendar Page
- Today's feeding summary
- Next feeding predictions
- Weekly feeding statistics
- Date-formatted displays

### ⚙️ Settings Page
- Baby profile management
- Notification preferences
- App customization options
- Data backup settings

## Mobile App Behavior

The application is designed to feel like a native mobile app:

- **Fixed Bottom Navigation**: Always accessible navigation bar
- **Touch-Friendly**: Large touch targets and intuitive gestures
- **Mobile-First CSS**: Responsive design that prioritizes mobile experience
- **App-Like Meta Tags**: Configured for iOS/Android home screen installation
- **No Zoom**: Prevents unwanted zooming on mobile devices

## Development

The project follows clean architecture principles:

- **Code-Behind Pattern**: Logic separated from markup using `.razor.cs` files
- **Component-Based**: Modular Blazor components
- **Mobile-First CSS**: Responsive design starting from mobile
- **Clean Separation**: Layout, pages, and styles organized logically

## Deployment

### Automated Deployment

The project includes automated deployment to GitHub Container Registry on every push to the `main` branch using semantic versioning.

#### How it works:

1. **Semantic Release**: Automatically determines version based on conventional commit messages
2. **Docker Build**: Multi-platform container build (linux/amd64, linux/arm64)
3. **Container Registry**: Pushes to GitHub Container Registry (`ghcr.io/spindev/feediary-new`)

#### Commit Message Format:

Use conventional commit messages to trigger appropriate version bumps:

- `feat:` - New feature (minor version bump)
- `fix:` - Bug fix (patch version bump)  
- `BREAKING CHANGE:` - Breaking change (major version bump)
- `docs:`, `style:`, `refactor:`, `test:`, `build:`, `ci:` - Patch version bump

Example:
```bash
git commit -m "feat: add feeding timer functionality"
git commit -m "fix: resolve mobile navigation issue"
git commit -m "feat!: redesign data storage (BREAKING CHANGE)"
```

#### Running the Container:

After deployment, the latest version is available at:

```bash
# Pull and run latest version
docker run -d -p 8080:8080 ghcr.io/spindev/feediary-new:latest

# Or run a specific version
docker run -d -p 8080:8080 ghcr.io/spindev/feediary-new:v1.2.3
```

### Manual Deployment

### Docker Production Deployment

The included Dockerfile creates an optimized production build:

- Multi-stage build for smaller image size
- Security best practices with non-root user
- Optimized for container environments
- Exposes port 8080 for easy deployment

### Self-Hosting

Perfect for families who want to keep their baby's data private:

```bash
docker run -d -p 8080:8080 --name feediary feediary:latest
```

## Contributing

1. Fork the repository
2. Create a feature branch
3. Commit your changes
4. Push to the branch
5. Create a Pull Request

## License

This project is open source and available under the MIT License.