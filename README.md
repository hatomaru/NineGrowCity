- How a reusable framework can accelerate experimental game prototyping

---

## AI Usage

AI is used in the following limited and controlled ways:

1. **Intent-Based Selection Tasks**  
   Each turn, the player inputs how they would like the city to change  
   (e.g. the kind of atmosphere, values, or direction they want to emphasize).

   The LLM interprets this **player intent** and maps it to predefined options  
   such as building types.  
   The AI does not freely generate content, but instead acts as an **interpreter**
   that translates language into structured game decisions.

2. **Evolution Comments**  
   When the city evolves, the AI outputs short textual descriptions that explain
   the change in a human-readable way, reflecting the interpreted intent.

3. **Final Evaluation**  
   At the end of the game, the AI generates a summary comment based on the city's
   final state and score, describing what kind of city has emerged.

> The AI does **not** generate core game logic.  
> All rules, scoring, and progression systems are implemented deterministically in code.


## Project Status

- ・Actively under development
- ・Core game loop implemented
- ・AI integration in progress
- ・Visuals and animations are minimal and experimental

This repository currently includes **scripts only**, focusing on logic and framework integration.

---
