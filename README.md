# Loan System

## Overview

The Loan System API is a simple web API designed to calculate loan interests based on different scenarios.

## Example Request

To calculate a loan amount, send a POST request to the `/api/loan/calculate` endpoint with the following JSON payload:

```json
{
  "clientId": "34b1a095-ce12-4b0d-bc12-9281b0fd42d5",
  "amount": 4500,
  "period": 13
}
```
Expected result: `4596.75`