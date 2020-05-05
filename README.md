# Game Ideas

## Dispositions

- Morality: selfish behaviour vs. behaviour that benefits others (regardless of relation)
- Loyalty: special treatment of those with good relations or similar alignment
- Passion: driven by money vs. professional development
- Sponteniety: the probability of taking a random action

## Alignment

Characters all have a national alignment that determines how they treat those of similar or different nationality.

Characters have a relationship quality measure with every other character that determines how they treat, interact with, and barter with other characters. This measure is affected by quality and frequency of interactions and trades.

## Professions

Professions largly determine high level character choices.

- Smith
- Explorer
- Miner
- Politician
- Mercenary
- Thief
- Trader

## Action Space

Each action ends when the task is complete, after a certain amount of time, or if an exceptional event triggers a break.

Most actions can be performed by either a bot or the character themselves. Bots are controlled just as an AI would control itself.

- Mine / gather resources
  - Specify type of resource
  - Pathfind to nearest discovered resource, otherwise explore
- Craft equipment / items
  - Specify type of item and craft
- Build building / establish city
  - Specify type of building
  - Select default template
  - Select location based on location score (proximity to resources, within city boundaries)
  - Begin building
- Explore
  - Exploration algorithm (Flood fill / A*)
- Combat: attack / defend
  - Specify Target and duration
- Sell / purchase item
  - Propose trade
  - Accept, counter, or cancel
  - AI will accept within certain threshold based on value attribution
  - AI counters / proposes based on different threshold
  - AI cancels after certain number of turns based on current relationship
- Service: attack / defend
  - Can be used as part of a conditional trade
  - Condition is met if target is destroyed / protected after specified time
- Thieving
  - Theiving occurs based on relation, disposition, item value
  - Attempt occurs when probability of success reaches threshold
- Rest
  - Staying in one's home gradually increases one's health
  - The player character can rest in a bed and time will pass in the world 

## Craft tree