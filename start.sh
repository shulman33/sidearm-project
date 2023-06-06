#!/bin/bash
cd /Users/samshulman/Desktop/SIDEARM/cms-project/front-end/cms
npm run dev -- --port 5174&
cd /Users/samshulman/Desktop/SIDEARM/cms-project/front-end/YUMacs
npm run dev -- --port 5175&
cd /Users/samshulman/Desktop/SIDEARM/cms-project/front-end/CMSApi/CMSApi
dotnet run --urls=https://localhost:7182