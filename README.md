# Stats

### Summary
Current configuration provides news story sentiment analysis (using a web based Machine Learning Sentiment API) for Major League Soccer players. (league roster from 2015)

0. Does not take user input.
1. Gets list of players and their stats from a csv in local directory.
2. Uses Bing News Search to find stories related to specific players.
3. Prints summary of stories to console.
4. Uses Microsoft Cognitive Services machine learning API to analyze stories for positive or negative sentiment.
5. Prints sentiment rating, as a percent positive, to console in front of summary.

#### Notes
Program includes methods to print stats of selected or all players.  Requires reconfiguration of Program.cs to do so.

Includes many commented lines of code and notes for myself.  I do not intend to clean them up.  This is primarily just a reference project for myself.

#### Future Plans
This project successfully demonstrates a number of important techniqes and tools, which was it's intended purpose.

Some Topics Covered: File and Console I/O, Encoding, Read/Parse CSV/JSON, Dese/Serialization, WebClient, interaction with and data deserialization from third party API.

Leaving up for reference.

#### Updates
04/05/2018 - Not currently interested in expanding on this project.
