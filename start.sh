#!/bin/bash
cd /Users/samshulman/Desktop/SIDEARM/cms-project/front-end/cms
npm run dev &
cd /Users/samshulman/Desktop/SIDEARM/cms-project/front-end/CMSApi/CMSApi
dotnet run --urls=https://localhost:7182