# CatWorx Badge Maker

The CatWorx Badge Maker is a console application designed to generate employee badges either by fetching employee data from an external API or by manually entering the data through the console. The application creates a CSV file with employee details and generates personalized badges with employee photos.

![C#](https://img.shields.io/badge/language-C%23-blue.svg)
![SkiaSharp](https://img.shields.io/badge/SkiaSharp-2.80.2-blue.svg)

## Table of Contents

- [Installation](#installation)
- [Usage](#usage)
  - [Manual Data Entry](#manual-data-entry)
  - [Fetching Data from API](#fetching-data-from-api)
- [Features](#features)
- [Dependencies](#dependencies)
- [Configuration](#configuration)
- [Examples](#examples)
- [Troubleshooting](#troubleshooting)
- [Contributors](#contributors)
- [License](#license)

## Installation

To install the CatWorx Badge Maker, ensure you have the .NET Core SDK installed on your machine. Clone the repository to your local machine, navigate to the project directory, and build the application using the .NET CLI.

## Usage

The CatWorx Badge Maker can be used in two modes: Manual Data Entry and Fetching Data from API.

### Manual Data Entry

To manually enter employee data, run the application and follow the on-screen prompts to enter employee details such as first name, last name, ID, and photo URL.

### Fetching Data from API

The application can also automatically fetch employee data from the "randomuser.me" API and generate badges for the fetched employees. This mode does not require manual data entry.

## Features

- **Manual Data Entry**: Enter employee details manually through the console.
- **API Data Fetch**: Automatically fetch employee data from an external API.
- **CSV Generation**: Generate a CSV file containing employee details.
- **Badge Generation**: Generate personalized employee badges with photos.

## Dependencies

- .NET Core SDK
- Newtonsoft.Json for parsing JSON data
- SkiaSharp for image processing and badge generation

## Configuration

No additional configuration is required to run the application in its default state. Ensure that the "badge.png" background image exists in the project directory for badge generation.

## Examples

![image](https://github.com/LandoCodesRissian/CatWorx_SecurityBadge/assets/141693593/e26efe2d-97ec-4620-8bbe-e4376174e186)

## Troubleshooting

If you encounter any issues with badge generation, ensure that the "badge.png" file is present and correctly named in the project directory. Also, verify that the photo URLs provided for employees are valid and accessible.

## Contributors

[Me!](https://github.com/LandoCodesRissian)

## License

This project is licensed under the MIT License.
