## Project Overview

**What it does**  
This project reads submissions from a source form (for example, Google Forms or Typeform), logs them to a local or remote store (such as a CSV file, SQLite, or a cloud database), and then automatically forwards the same data to a target form (for instance, a CRM web form or another survey). It can run once on demand or be scheduled to run periodically.

**Why it’s useful**  
- It removes the need to copy and paste data between different form systems.  
- It ensures that information is forwarded accurately, reducing human error.  
- If logging is enabled, you will have an audit trail for compliance or reporting purposes.

---

## Features

- Automated data forwarding from one form URL to another.  
- Submission logging to a CSV file, SQLite database, PostgreSQL, or cloud storage.  
- Support for secure endpoints using API keys or OAuth tokens.  
- Scheduling support via Cron or a built-in scheduler.  
- Configurable field mappings to match field names between source and target forms.  
- Headless-browser automation (using Selenium or Playwright) or direct HTTP POST, depending on the requirements of the target form.

---

## Getting Started

### Prerequisites

Before you begin, make sure you have the following software installed:

- Python 3.8 or higher.  
- pip (or pipenv / virtualenv) for managing Python packages.  
- Google Chrome (or another Chromium-based browser) if you plan to use Selenium or Playwright.  
- ChromeDriver (matching your Chrome version) or another appropriate WebDriver, available in your system’s PATH.  
- If your project logs data to a database, have SQLite, PostgreSQL, or your database of choice running.  
- (Optional) Node.js 14 or higher and npm (or yarn) if the repository includes a frontend component.

### Installation

1. **Clone the repository**  
   ```bash
   git clone https://github.com/KatrielMoses/form-submission-automation.git
   cd form-submission-automation
