# Nine GrowCity (Working Title)

Nine GrowCity is a small experimental game currently under development.  
This project is being built as a **demo game for a local LLM framework**, exploring how AI-driven decisions and language can be translated into game progression within a limited number of turns.

> This repository is **work in progress**.  
> The implementation, structure, and content may change significantly.

---

## Overview

Nine GrowCity is a turn-based city-building experiment where the player interacts with an AI through language.

- The game progresses over **9 turns**
- Each turn, the AI makes **bounded decisions** (selection tasks)
- AI-generated comments describe **city evolution and state**
- The final result evaluates the city based on internal scores and evolution stages

The goal of this project is not to create a full commercial game, but to demonstrate:
- How a **local LLM** can be integrated into a Unity game loop
- How AI decisions can be made **interpretable and meaningful** through UI and language
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
