# Observability Example

A demonstration project showcasing observability practices using C# microservices with the Grafana observability stack.

## Project Overview

This repository contains an example application that demonstrates observability patterns in a microservice architecture. It consists of two services (WebServiceA and WebServiceB) built with .NET and instrumented for comprehensive monitoring and observability using the Grafana stack.

## Services

### WebServiceA
A .NET web service that provides API endpoints and communicates with WebServiceB.

### WebServiceB
A .NET web service that receives requests from WebServiceA and processes them.

## Grafana Observability Stack

This project demonstrates the implementation of the complete Grafana observability stack:

### Grafana
- **Dashboard Platform**: Centralized visualization for all observability data
- **Alert Manager**: Configured alerts based on metrics and logs
- **Custom Dashboards**: Pre-built dashboards for service metrics and traces

### Prometheus
- **Metrics Collection**: Collects and stores metrics from both services
- **Service Health**: Monitors service health and performance metrics
- **Custom Metrics**: Implementation of custom business metrics
- **PromQL**: Examples of useful queries for monitoring service behavior

### Loki
- **Log Aggregation**: Centralized logging infrastructure
- **Log Queries**: Search and analyze logs across services
- **Log Labels**: Structured logging with appropriate labels for filtering
- **Log Correlation**: Correlate logs with traces and metrics

### Tempo
- **Distributed Tracing**: End-to-end request tracing across services
- **Trace Sampling**: Configured sampling strategies
- **Trace Context**: Proper context propagation between services
- **Trace Visualization**: Integration with Grafana dashboards

### OpenTelemetry
- **.NET Integration**: Configuration of OpenTelemetry in .NET services
- **Auto-Instrumentation**: Automatic instrumentation of HTTP requests and dependencies
- **Manual Instrumentation**: Examples of custom span creation and attribute tagging
- **Context Propagation**: Proper context handling between services

## Getting Started

### Prerequisites

- .NET 6.0 or later
- Docker and Docker Compose
- Your preferred IDE (Visual Studio, VS Code, Rider, etc.)

### Running the Application with Observability Stack

1. Clone the repository
   ```
   git clone https://github.com/alimahboubi/Observability-Example.git
   cd Observability-Example
   ```

2. Build and run the services with the observability stack
   ```
   docker-compose up --build
   ```

3. Access the services and observability tools:
   - WebServiceA: http://localhost:5001
   - WebServiceB: http://localhost:5002
   - Grafana: http://localhost:3000
   - Prometheus: http://localhost:9090
   - Loki UI: Available through Grafana
   - Tempo UI: Available through Grafana

## Project Structure

```
Observability-Example/
├── WebServiceA/              # Main API service
│   ├── Controllers/          # API endpoints
│   ├── Models/               # Data models
│   ├── Services/             # Business logic and external services
│   └── Dockerfile            # Container configuration
├── WebServiceB/              # Secondary service
│   ├── Controllers/          # API endpoints
│   ├── Services/             # Business logic
│   └── Dockerfile            # Container configuration
└── Infrastracture/           # Infrastructure configuration
    ├── grafana/              # Grafana configuration and dashboards
    ├── prometheus/           # Prometheus configuration
    ├── loki/                 # Loki configuration
    ├── tempo/                # Tempo configuration
    └── docker-compose.yml    # Orchestration of all services
```

## Observability Configuration

### Metrics Configuration
- **Service Metrics**: CPU, memory, request rates, response times
- **Business Metrics**: Custom metrics for business processes
- **Prometheus Endpoints**: Configured on both services
- **Metric Naming**: Consistent naming conventions for all metrics

### Logging Configuration
- **Structured Logging**: JSON-formatted logs with consistent fields
- **Log Levels**: Proper use of log levels (DEBUG, INFO, WARNING, ERROR)
- **Context Enrichment**: Adding trace IDs and service information to logs
- **Log Routing**: Configuration of log shipping to Loki

### Tracing Configuration
- **Span Creation**: Automatic and manual span creation examples
- **Span Attributes**: Useful attributes for debugging and analysis
- **Sampling Rates**: Configuration of appropriate sampling strategies
- **Baggage & Context**: Passing relevant information between services

### Dashboard Examples
- **Service Overview**: High-level service health and performance
- **Request Tracing**: Detailed request flow visualization
- **Error Analysis**: Quickly identify and diagnose errors
- **Business Metrics**: Monitor key business indicators

## License

[MIT License](LICENSE)

## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.

## Contact

Ali Mahboubi - [GitHub Profile](https://github.com/alimahboubi)

Project Link: [https://github.com/alimahboubi/Observability-Example](https://github.com/alimahboubi/Observability-Example)

Last Updated: 2025-06-06