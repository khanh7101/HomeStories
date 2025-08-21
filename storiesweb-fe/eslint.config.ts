// eslint.config.ts
import js from "@eslint/js";
import globals from "globals";
import reactHooks from "eslint-plugin-react-hooks";
import reactRefresh from "eslint-plugin-react-refresh";
import tseslint from "typescript-eslint";

import sheriff from "eslint-config-sheriff";
import type { SheriffSettings } from "@sherifforg/types";

const sheriffOptions: SheriffSettings = {
  react: true,
  vitest: true,
};

export default [
  { ignores: ["dist"] },
  ...sheriff(sheriffOptions),
  {
    files: ["**/*.{ts,tsx}"],
    extends: [
      js.configs.recommended,
      tseslint.configs.recommended,
      reactHooks.configs["recommended-latest"],
      reactRefresh.configs.vite,
    ],
    languageOptions: {
      ecmaVersion: 2020,
      globals: globals.browser,
      parser: tseslint.parser,
    },
    rules: {
      "prettier/prettier": "error",
    },
  },
];
